using LinkedList;

namespace Tests
{
    public class LinkedListTests
    {
        [Test]
        public void GivenLinkedList_WhenInitialized_ThenCreateNewLinkedListWith0Nodes()
        {
            // arrange
            var list = new LinkedList.LinkedList<int>();

            // act/assert
            Assert.That(list.Count, Is.EqualTo(0));
        }

        [Test]
        public void GivenLinkedList_WhenTwoNodesPushed_ThenListContainsTwoNodesInCorrectOrder()
        {
            // arrange
            var list = new LinkedList.LinkedList<string>();

            // act
            list.Push("A");
            list.Push("B");

            // assert
            Assert.That(list.Count, Is.EqualTo(2));
            Assert.That(list.Head!.Data, Is.EqualTo("B"));
            Assert.That(list.Head.Next!.Data, Is.EqualTo("A"));
        }

        [Test]
        public void GivenLinkedList_WhenRemove_ThenReturnFirstNodeAndRemoveFromLinkedList()
        {
            // arrange
            var list = new LinkedList.LinkedList<string>();
            list.Push("A");
            list.Push("B");

            // act
            list.Remove("B");

            // assert
            Assert.That(list.Count, Is.EqualTo(1));
        }

        [Test]
        public void GivenEmptyLinkedList_WhenRemoveAnEmptyLinkedList_ThrowsInvalidOperationalException()
        {
            // arrange
            var list = new LinkedList.LinkedList<string>();

            // act / assert
            Assert.Throws<InvalidOperationException>(() => list.Remove(""));
        }

        [Test]
        public void GivenLinkedList_WhenRemoveMiddleData_ThenMoveTo2()
        {
            // arrange
            var list = new LinkedList.LinkedList<string>();
            list.Push("A");
            list.Push("B");
            list.Push("C");

            // act
            list.Remove("B");

            // assert
            Assert.That(list.Count, Is.EqualTo(2));
        }

        [Test]
        public void GivenLinkedList_WhenTryToRemoveAnNonExistingData_NodesAreStable()
        {
            // arrange
            var list = new LinkedList.LinkedList<string>();
            list.Push("A");
            list.Push("B");
            list.Push("C");

            // act
            list.Remove("D");

            // assert
            Assert.That(list.Count, Is.EqualTo(3));
        }
    }
}
