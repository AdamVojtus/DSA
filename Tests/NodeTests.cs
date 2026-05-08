using Trees;

namespace Tests
{
    public class NodeTests
    {
        [Test]
        public void GivenNode_WhenTreeIsCreated_ThenStructureIsValid()
        {
            // arrange
            var inputs = new int[] { 1, 2, 3 };

            // act
            var result = Node.CreateBalancedTree(inputs);

            // assert
            Assert.That(result!.IsValid(), Is.True);
            Assert.That(result.Value, Is.EqualTo(2));
            Assert.That(result.Left!.Value, Is.EqualTo(1));
            Assert.That(result.Right!.Value, Is.EqualTo(3));
        }

        [Test]
        public void GivenNode_WhenFlattened_ThenDataMatchesSortedUniqueInput()
        {
            // arrange
            var inputs = new int[] { 5, 2, 10, 1, 13, 5, 14, 12, 11 };
            var expected = new int[] { 1, 2, 5, 5, 10, 11, 12, 13, 14 };


            // act
            var root = Node.CreateBalancedTree(inputs);
            var result = root!.FlattenSorted();

            // assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void GivenNode_WhenTreeIsCreated_ThenSpecificStructureIsValid()
        {
            // arrange
            var inputs = new int[] { 5, 2, 10, 1, 13, 5, 14, 12, 11 };

            // act
            var result = Node.CreateBalancedTree(inputs);

            // assert
            Assert.That(result!.IsValid(), Is.True);
        }

        [Test]
        public void GivenNode_WhenValidChildScenariosArePresented_ThenNoExceptionThrown()
        {
            // act/assert
            Assert.DoesNotThrow(() => new Node(5, new Node(4), new Node(5)));
        }

        [Test]
        public void GivenNode_WhenLeftChildIsInvalid_ThenThrowArgumentException()
        {
            // arrange
            var invalidLeftChild = new Node(5);

            // act/assert
            Assert.Throws<System.ArgumentException>(() => new Node(5, invalidLeftChild, null));
        }

        [Test]
        public void GivenNode_WhenRightChildIsInvalid_ThenThrowArgumentException()
        {
            // arrange
            var invalidRightChild = new Node(4);

            // act/assert
            Assert.Throws<System.ArgumentException>(() => new Node(5, null, invalidRightChild));
        }
    }
}