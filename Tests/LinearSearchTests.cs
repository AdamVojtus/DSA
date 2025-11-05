using LinearSearch;

namespace Tests
{
    public class LinearSearchTests
    {
        [Test]
        public void GivenLinearSearchForArray_WhenCalled_SearchForSpecificValue()
        {
            // arrange
            var numbers = new int[] { 10, 20, 30, 40 };
            int result;
            bool found = LinearSearch<int>.Search(30, numbers, out result);

            // act/assert
            Assert.That(result, Is.EqualTo(30));
            Assert.That(found, Is.True);
        }

        [Test]
        public void GivenLinearSearchForArray_WhenCalledAndSearchesForNonexistingValue_ThrowsInvalidOperationException()
        {
            // arrange
            var numbers = new int[] { 10, 20, 30, 40 };

            // act/assert
            Assert.Throws<InvalidOperationException>(() =>
            {
                int result;
                bool found = LinearSearch<int>.Search(0, numbers, out result);
                if (!found)
                    throw new InvalidOperationException();
            });
        }

        [Test]
        public void GivenLinearSearchForEmptyArray_WhenCalledAndSearchesForNonexistingValue_ThrowsInvalidOperationException()
        {
            // arrange
            var numbers = new int[] { };

            // act/assert
            Assert.Throws<InvalidOperationException>(() =>
            {
                int result;
                bool found = LinearSearch<int>.Search(0, numbers, out result);
                if (!found)
                    throw new InvalidOperationException();
            });
        }

        [Test]
        public void Search_ShouldReturnDefault_WhenValueNotFound_ButDefaultExistsInArray()
        {
            // Arrange
            int[] numbers = { 0, 1, 2, 3 };
            int valueToSearch = 99;

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                int result;
                bool found = LinearSearch<int>.Search(valueToSearch, numbers, out result);
                if (!found && Array.Exists(numbers, n => n.Equals(default(int))))
                    throw new ArgumentOutOfRangeException();
            });
        }
    }
}
