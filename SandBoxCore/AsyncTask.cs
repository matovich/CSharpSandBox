using System.Threading;
using System.Threading.Tasks;

namespace SandBoxCore
{
    public class AsyncTask
    {
        private readonly ITaskMaker<int> _maker;
        private readonly TaskFactory _taskFactory;

        public AsyncTask()
        {
        }

        public AsyncTask(ITaskMaker<int> maker)
        {
            _maker = maker;
        }

        public AsyncTask(TaskScheduler scheduler)
        {
            _taskFactory = new TaskFactory(scheduler);
        }

        public int Value { get; set; }

        public void AddAsyncWithMaker()
        {
            Task<int> task = _maker.GetTask();

            task.ContinueWith(t => Thread.Sleep(2000), TaskContinuationOptions.NotOnFaulted | TaskContinuationOptions.ExecuteSynchronously)
                .ContinueWith(t1 => Thread.Sleep(2000), TaskContinuationOptions.NotOnFaulted | TaskContinuationOptions.ExecuteSynchronously)
                .ContinueWith(t1 => Thread.Sleep(2000), TaskContinuationOptions.NotOnFaulted | TaskContinuationOptions.ExecuteSynchronously)
                .ContinueWith(t1 =>
                {
                    Thread.Sleep(2000);
                    Value = task.Result;
                }, TaskContinuationOptions.NotOnFaulted | TaskContinuationOptions.ExecuteSynchronously);
        }

        public void AddAsync(int value)
        {
            Task<int> task = Task.Factory.StartNew(() => Value += value);
            task.ContinueWith(t => { Value = t.Result; });
        }

        public void AddAsyncWithScheduler(int value)
        {
            Task<int> task = _taskFactory.StartNew(() => Value += value);
            task.ContinueWith(t => Value = t.Result);
        }
    }

    public interface ITaskMaker<T>
    {
        Task<T> GetTask();
    }

    public class TaskMaker<T> : ITaskMaker<T>
    {
        private readonly Task<T> _task;

        public TaskMaker(Task<T> task)
        {
            _task = task;
        }

        public virtual Task<T> GetTask()
        {
            _task.RunSynchronously();
            //_Task.Start();
            return _task;
            //   return  Task.Factory.StartNew(() => { return 0; });
        }
    }
}