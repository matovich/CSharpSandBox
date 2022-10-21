using System.Threading;
using System.Threading.Tasks;

namespace SandBox
{
    public class AsyncTask
    {
        private readonly ITaskMaker _maker;
        private readonly TaskFactory _taskFactory;

        public AsyncTask()
        {
        }

        public AsyncTask(ITaskMaker maker)
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

        //private void ContinuePopulateUnitPatientsTask( Task<Tuple<Int32, IEnumerable<IPatient>>> patientsTask )
        //{
        //    var uiTaskScheduler = TaskScheduler.FromCurrentSynchronizationContext();

        //    patientsTask.ContinueWith( t => HandleFaultedPatientLoadTask( t.Exception ), CancellationToken.None, TaskContinuationOptions.OnlyOnFaulted | TaskContinuationOptions.ExecuteSynchronously, uiTaskScheduler )
        //        .ContinueWith( task => _logger.Debug( () => String.Format( CultureInfo.InvariantCulture, "Exception encountered while attempting to handle fault during populating all patients. {0}", task.Exception.InnerException.Message ) ), TaskContinuationOptions.OnlyOnFaulted | TaskContinuationOptions.ExecuteSynchronously );

        //    patientsTask.ContinueWith( t => HandlePatientLoadingTask( t.Result.Item1, t.Result.Item2 ), CancellationToken.None, TaskContinuationOptions.NotOnFaulted | TaskContinuationOptions.ExecuteSynchronously, uiTaskScheduler )
        //        .ContinueWith( erroredTask => HandleFaultedPatientLoadTask( erroredTask.Exception ), CancellationToken.None, TaskContinuationOptions.OnlyOnFaulted | TaskContinuationOptions.ExecuteSynchronously, uiTaskScheduler )
        //        .ContinueWith( task => _logger.Debug( () => String.Format( CultureInfo.InvariantCulture, "Exception encountered while attempting to handle fault during populating all patients. {0}", task.Exception.InnerException.Message ) ), TaskContinuationOptions.OnlyOnFaulted | TaskContinuationOptions.ExecuteSynchronously );
        //}
    }

    public interface ITaskMaker
    {
        Task<int> GetTask();
    }

    public class TaskMaker : ITaskMaker
    {
        private readonly Task<int> _task;

        public TaskMaker(Task<int> task)
        {
            _task = task;
        }

        public virtual Task<int> GetTask()
        {
            _task.RunSynchronously();
            //_Task.Start();
            return _task;
            //   return  Task.Factory.StartNew(() => { return 0; });
        }
    }
}