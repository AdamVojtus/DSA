using System.Collections;

namespace Tests
{
    public class StackTests
    {
        [Test]
        public void GivenStack_WhenInitialized_ThenCreateNewInstanceWithZeroItems()
        {
            // arrange / act
            var stack = new Stack();
           
            // assert
            Assert.That(stack.Count, Is.EqualTo(0));
        }

        [Test]
        public void GivenStack_WhenInitializedTo1AndPushWithNoSpace_ThenResizeAndAllowPush()
        {
            // arrange
            var stack = new Stack(1);

            // act
            stack.Push(1);

            // Resize internally and allow push
            stack.Push(2);
            stack.Push(3);

            // assert
            Assert.That(stack.Count, Is.EqualTo(3));
        }

        [Test]
        public void GivenStack_WhenPop_ThenReturnLastItemAndRemoveFromStack()
        {
            // arrange
            var stack = new Stack();
            stack.Push(1);
            stack.Push(2);

            // act
            var lastItem = stack.Pop();

            // assert
            Assert.That(lastItem, Is.EqualTo(2));
            Assert.That(stack.Count, Is.EqualTo(1));
        }

        [Test]
        public void GivenEmptyStack_WhenTryToPopEmptyStack_ThenReturnNull()
        {
            var stack = new Stack();

            Assert.Throws<InvalidOperationException>(() => stack.Pop());
        }
    }
}