using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Reactive.Concurrency;
using System.Runtime.InteropServices;

namespace SandBoxCore
{
    public class RxNet
    {
        IDisposable subscription1;
        IDisposable subscription2;

        public RxNet()
        {
            //var sub = new System.Reactive.Subjects.Subject<string>();
            //var subscription = sub.Do(s => Console.WriteLine(s)).Throttle(TimeSpan.FromMilliseconds(500)).Subscribe();
            //subscription.Dispose();
        }

        public void Run()
        {
            Console.WriteLine("Main Thread ID: " +  Thread.CurrentThread.ManagedThreadId);
            var observable1 = ObervableFactory("One");
            var observable2 = ObervableFactory("Two");

            subscription1 = observable1.ObserveOn(ThreadPoolScheduler.Instance).Subscribe(OnNext, e => OnError(e, 1), () => OnCompleted(1)); //.Throttle(TimeSpan.FromMilliseconds(0)).ObserveOn(ThreadPoolScheduler.Instance)
            Console.WriteLine("Subscription One Running");
            subscription2 = observable2.ObserveOn(ThreadPoolScheduler.Instance).Subscribe(OnNext, e => OnError(e, 2), () => OnCompleted(2));
            Console.WriteLine("Subscription Two Running");
        }

        private void OnCompleted(int runId)
        {
            Console.WriteLine($"{runId} is done.");
            if(runId == 1)
            {
                subscription1?.Dispose();
            }
            else
            {
                subscription2?.Dispose();
            }
        }

        private void OnError(Exception ex, int runId)
        {
            if (runId == 1)
            {
                subscription1?.Dispose();
            }
            else
            {
                subscription2?.Dispose();
            }
            throw new Exception("Things did not go well.", ex);
        }

        private void OnNext(string value)
        {
            Console.WriteLine($"Thread Id: {Thread.CurrentThread.ManagedThreadId} - {value}");
        }

        /// <summary>
        /// Code copied from https://riptutorial.com/system-reactive
        /// </summary>
        private IObservable<string> ObervableFactory(string identifier)
        {
            return Observable.Create<string>(o =>
            {
                string SearchText = $"{identifier} C# Reactive Extensions";

                var builder = new StringBuilder();
                foreach (var c in SearchText)
                {
                    builder.Append(c);

                    // notify that the search text has been changed
                    o.OnNext(builder.ToString());
                }

                o.OnCompleted();

                return () => { /* nothing to dispose here */ };
            });
        }
    }
}
