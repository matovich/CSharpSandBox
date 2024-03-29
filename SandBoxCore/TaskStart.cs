﻿//using System;
//using System.Collections.Concurrent;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Forms.VisualStyles;

//namespace SandBoxCore
//{
//    public class TaskStart
//    {
//        public async void Run()
//        {
//            await new TestableProductionTaskClass().Run();

//            var t1 = new Task(() => Console.WriteLine("Test Task.Start"));
//            t1.Start();
//            Console.WriteLine("   Test.Start - Started...");
//            Console.WriteLine();

//            var t2 = Task.Factory.StartNew(() => Console.WriteLine("Test TaskFactory"));
//            Console.WriteLine("   Task.Factory Started...");
//            Console.WriteLine();

//            var t3 = Task.Run(() => Console.WriteLine("Test Task.Run"));
//            Console.WriteLine("   Task.Run Started...");

//            await t2;
//            t2.Dispose();
//            await t3;
//            t3.Dispose();
//            await t1;
//            t1.Dispose();

//            await CancelTokenTask();
//        }

//        private void Play()
//        {
//            var q = new ConcurrentQueue<string>();
//            q.Enqueue("Hello");
//            if(q.TryDequeue(out var item))
//            {
//                Console.WriteLine(item);
//            }

//            var l = new ConcurrentBag<string>();
//            l.Add("Hello");
//            if(l.TryTake(out var item2))
//            {
//                Console.WriteLine(item2);
//            }

//        }

//        private static async Task CancelTokenTask()
//        {
//            var cancellationTokenSource = new CancellationTokenSource();
//            var ct = cancellationTokenSource.Token;
//            var t4 = Task.Run(() =>
//            {
//                NeverEnding(ct);
//            }, ct);

//            Thread.Sleep(10);
//            cancellationTokenSource.Cancel();
//            try
//            {
//                // The await brings the exception back onto this thread.
//                await t4;
//            }
//            catch (OperationCanceledException)
//            {
//                Console.WriteLine($"{Environment.NewLine}Canceled");
//            }
//            finally
//            {
//                cancellationTokenSource.Dispose();
//                t4.Dispose();
//            }
//        }

//        private static void NeverEnding(CancellationToken ct)
//        {
//            Console.WriteLine("Cancellation Task Run");
//            while (true)
//            {
//                ct.ThrowIfCancellationRequested();
//                // or
//                //if(ct.IsCancellationRequested )
//                //{
//                //    break;
//                //}
//                Console.Write("t "); 
//            }
//        }
//    }

//    public class ProductionTaskClass
//    {
//        public async Task Run()
//        {
//            var t1 = new Task(() => Console.WriteLine("Production Task Class"));
//            StartTask(t1);
//            Console.WriteLine($"   Production Task Class - Done...{Environment.NewLine}");
//            await t1;
//            t1.Dispose();
//        }

//        protected virtual void StartTask(Task task)
//        {
//            task.Start();
//        }

//        protected virtual void StartTask<T>(Task<T> task)
//        {
//            task.Start();
//        }
//    }

//    public class TestableProductionTaskClass : ProductionTaskClass
//    {
//        protected override void StartTask(Task task)
//        {
//            task.RunSynchronously();
//        }
//    }
//}
