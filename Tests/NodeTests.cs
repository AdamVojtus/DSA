using Trees;

namespace Tests
{
    public class NodeTests
    {
        [Test]
        public void GivenArray_WhenRootExists_ThenReturnTrue()
        {
            var inputs = new int[] { 5, 2, 10, 1, 13, 5, 14, 12, 11 };
            var result = Node.CreateBalancedTree(inputs);

            Assert.That(result, Is.Not.Null);
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

        [Test]
        public void GivenArrayWithDuplicate_WhenTreeCreated_ThenRootIsTenLeftIsNineRightIsTen()
        {
            // arrange
            var inputs = new int[] { 10, 9, 10 };

            // act
            var result = Node.CreateBalancedTree(inputs);

            // assert
            Assert.Multiple(() =>
            {
                Assert.That(result!.Value, Is.EqualTo(10));
                Assert.That(result.Left!.Value, Is.EqualTo(9));
                Assert.That(result.Right!.Value, Is.EqualTo(10));
            });
        }
    }
}