using System.Collections;

namespace Tests
{
    public class QueueTests
    {
        [Test]
        public void GivenQueue_WhenInitialized_ThenCreateNewInstanceWith0Items()
        {
            // arrange / act
            var queue = new Queue();

            // assert
            Assert.That(queue.Count, Is.EqualTo(0));
        }

        [Test]
        public void GivenQueue_WhenInitialized_ThenCreateNewKeyToKeys()
        {
            // arrange
            var queue = new Queue(1);

            // act
            queue.Enqueue(1);

            // assert
            Assert.That(queue.Count, Is.EqualTo(1));
        }

        [Test]
        public void GivenQueue_WhenDequeue_ThenReturnFirstItemAndRemoveFromQueue()
        {
            // arrange
            var queue = new Queue();
            queue.Enqueue(1);
            queue.Enqueue(2);

            // act
            var firstKey = queue.Dequeue();

            // assert
            Assert.That(firstKey, Is.EqualTo(1));
            Assert.That(queue.Count, Is.EqualTo(1));
        }

        [Test]
        public void GivenEmptyQueue_WhenDequeueAnEmptyQueue_ThrowsInvalidOperationException()
        {
            // arrange
            var queue = new Queue();

            // act / assert
            Assert.Throws<InvalidOperationException>(() => queue.Dequeue());
        }
    }
}
