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
            Console.WriteLine("Thread ID: " +  Thread.CurrentThread.ManagedThreadId);
            var observable1 = ObervableFactory("One");
            var observable2 = ObervableFactory("Two");

            //System.Reactive.Concurrency.TaskPoolScheduler


            subscription1 = observable1.Throttle(TimeSpan.FromMilliseconds(1)).ObserveOn(ThreadPoolScheduler.Instance).Subscribe(OnNext, OnError, OnCompleted);
            Console.WriteLine("Subscription One Running");
            subscription2 = observable2.Throttle(TimeSpan.FromMilliseconds(1)).ObserveOn(ThreadPoolScheduler.Instance).Subscribe(OnNext2, OnError2, OnCompleted2);
            Console.WriteLine("Subscription Two Running");
        }

        private void OnCompleted()
        {
            Console.WriteLine("All done.");
            subscription1?.Dispose();
        }

        private void OnError(Exception ex)
        {
            subscription1?.Dispose();
            throw new Exception("Things did not go well.", ex);
        }

        private void OnNext(string value)
        {
            Console.WriteLine($"{value}    Thread Id: {Thread.CurrentThread.ManagedThreadId}");
        }

        private void OnError2(Exception ex)
        {
            subscription2?.Dispose();
            throw new Exception("Things did not go well.", ex);
        }

        private void OnNext2(string value)
        {
            Console.WriteLine($"{value}    Thread Id: {Thread.CurrentThread.ManagedThreadId}");
        }

        private void OnCompleted2()
        {
            Console.WriteLine("All done.");
            subscription2?.Dispose();
        }

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

                    // pause between each character to simulate actual typing
                    Thread.Sleep(125);

                    // spent some time to think about the next word to type
                    if (c == ' ')
                        Thread.Sleep(1000);
                }

                o.OnCompleted();

                return () => { /* nothing to dispose here */ };
            });
        }
    }
}
