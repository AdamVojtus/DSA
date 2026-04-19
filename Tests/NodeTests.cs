using Trees;

namespace Tests
{
    public class NodeTests
    {
        [Test]
        public void GivenNode_WhenSmallValuesInput_ThenTreeIsCreatedAndValid()
        {
            // arrange
            var inputs = new int[] { 1, 2, 3 };

            // act
            var result = Node.CreateBalancedTree(inputs);

            // assert
            Assert.Multiple(() =>
            {
                Assert.That(result, Is.Not.Null);
                Assert.That(result!.IsValid(), Is.True);
                Assert.That(result.Value, Is.EqualTo(2));
            });
        }

        [Test]
        public void GivenNode_WhenTreeIsCreated_ThenStructureIsValidBST()
        {
            // arrange
            var inputs = new int[] { 5, 2, 10, 1, 13, 5, 14, 12, 11 };

            // act
            var result = Node.CreateBalancedTree(inputs);

            // assert
            Assert.That(result!.IsValid(), Is.True);
        }

        [Test]
        public void GivenNode_WhenFlattened_ThenDataMatchesSortedUniqueInput()
        {
            // arrange
            var inputs = new int[] { 5, 2, 10, 1, 13, 5, 14, 12, 11 };
            var expected = Node.GetSortedValues(inputs);

            // act
            var root = Node.CreateBalancedTree(inputs);
            var result = root!.FlattenSorted();

            // assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void GivenNode_WhenInputHasDuplicates_ThenTreeContainsOnlyUniqueValues()
        {
            // arrange
            var inputs = new int[] { 10, 9, 10 };

            // act
            var result = Node.CreateBalancedTree(inputs);

            // assert
            Assert.Multiple(() =>
            {
                Assert.That(result, Is.Not.Null);
                Assert.That(result!.IsValid(), Is.True);
                Assert.That(result.Value, Is.EqualTo(10));
                Assert.That(result.Left!.Value, Is.EqualTo(9));
                Assert.That(result.Right, Is.Null);
            });
        }

        [Test]
        public void GivenNode_WhenRightChildIsInvalid_ThenThrowArgumentException()
        {
            // arrange
            var invalidRightChild = new Node(10);

            // act/assert
            Assert.Throws<System.ArgumentException>(() => new Node(10, null, invalidRightChild));
        }
    }
}