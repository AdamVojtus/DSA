using Trees;

namespace Tests
{
    public class NodeTests
    {
        [Test]
        public void GivenSortedArray_WhenRootExists_ThenReturnTrue()
        {
            var inputs = new int[] { 5, 2, 10, 1, 13, 5, 14, 12, 11 };
            var result = Node.CreateBalancedTree(inputs);

            Assert.That(result!.Value, Is.EqualTo(10));
        }

        [Test]
        public void GivenInvalidLeftNode_WhenLeftValueIsGreater_ThenThrowArgumentException()
        {
            var leftNode = new Node(15);
            Assert.Throws<System.ArgumentException>(() => new Node(10, leftNode, null));
        }

        [Test]
        public void GivenInvalidRightNode_WhenRightValueIsSmaller_ThenThrowArgumentException()
        {
            var rightNode = new Node(5);
            Assert.Throws<System.ArgumentException>(() => new Node(10, null, rightNode));
        }
    }
}