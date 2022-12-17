using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Runtime.InteropServices;

namespace SandBoxCore
{
    public class RxNet : IDisposable
    {
        IDisposable subscription;

        public RxNet()
        {
            //var sub = new System.Reactive.Subjects.Subject<string>();
            //var subscription = sub.Do(s => Console.WriteLine(s)).Throttle(TimeSpan.FromMilliseconds(500)).Subscribe();
            //subscription.Dispose();
        }

        public void Run()
        {
            var observable = ObervableFactory();
            subscription = observable.Throttle(TimeSpan.FromMilliseconds(1)).Subscribe(OnNext, OnError, OnCompleted);
        }

        private void OnCompleted()
        {
            Console.WriteLine("All done.");
        }

        private void OnError(Exception ex)
        {
            throw new Exception("Things did not go well.", ex);
        }

        private void OnNext(string value)
        {
            Console.WriteLine(value);
        }

        private IObservable<string> ObervableFactory()
        {
            return Observable.Create<string>(o =>
            {
                const string SearchText = "C# Reactive Extensions";

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

        public void Dispose()
        {
            if (subscription != null)
            {
                subscription.Dispose();
            }
        }
    }
}
