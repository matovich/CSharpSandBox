using NUnit.Framework;
using Moq;

namespace SandBoxCore.Test
{
    [TestFixture]
    public class AsyncTaskTest
    {
        [Test]
        public void AddAsyncWithMaker()
        {
            var taskSource = new TaskCompletionSource<int>();
            taskSource.SetResult(8);

            var taskMakerMock = new Mock<ITaskMaker<int>>();
            taskMakerMock.Setup(x => x.GetTask()).Returns(taskSource.Task);

            var target = new AsyncTask(taskMakerMock.Object) {Value = 4};

            target.AddAsyncWithMaker();
            taskSource.Task.Wait(5000);

            Assert.That(target.Value, Is.EqualTo(8));
        }

        [Test]
        public void AddAsyncWithMakerSecondProcess()
        {
            var task = new Task<int>(() => 5);

            var target = new AsyncTask(new TaskMaker<int>(task));
            target.AddAsyncWithMaker();

            task.Wait(5000);

            Assert.That(target.Value, Is.EqualTo(5));
        }

        // This is the best example so far.
        [Test]
        public void AddAsyncSecondAttempt()
        {
            var target = new AsyncTask {Value = 3};

            target.AddAsync(4);

            Thread.Sleep(2000);

            Assert.That(target.Value, Is.EqualTo(7));
        }

        [Test]
        public void AddAsyncTest()
        {
            var scheduler = new TestableScheduler();

            var target = new AsyncTask(scheduler) {Value = 3};
            target.AddAsyncWithScheduler(5);

            scheduler.RunAll();

            Thread.Sleep(2000);

            Assert.That(target.Value, Is.EqualTo(8));
        }
    }

    internal class TestableScheduler : TaskScheduler
    {
        private readonly Queue<Task> _mTaskQueue = new Queue<Task>();

        protected override IEnumerable<Task> GetScheduledTasks()
        {
            return _mTaskQueue;
        }

        protected override void QueueTask(Task task)
        {
            _mTaskQueue.Enqueue(task);
        }

        protected override bool TryExecuteTaskInline(Task task, bool taskWasPreviouslyQueued)
        {
            task.RunSynchronously();

            // the return true was not in the stack overflow post but I added it to get it to build.
            return true;
        }

        public void RunAll()
        {
            while (_mTaskQueue.Count > 0)
                _mTaskQueue.Dequeue().RunSynchronously();
        }
    }
}