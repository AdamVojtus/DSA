using Arrays;

namespace Tests
{
    public class SubsequenceTests
    {
        [Test]
        public void GivenMainArray_WhenMainLengthIsLessValueThenInputLength_ThenReturnFalse()
        {
            // arrange
            int[] main = { 1 };
            int[] input = { 1, 2, 3, 4 };

            // act
            var result = Subsequence.IsSubsequence(main, input);

            // assert
            Assert.IsFalse(result);
        }

        [Test]
        public void GivenMainArray_WhenItsEmptyAndInputArrayReachesForIt_ThenReturnFalse()
        {
            // arrange
            int[] main = { };
            int[] input = { 1 };

            // act
            var result = Subsequence.IsSubsequence(main, input);

            // assert
            Assert.IsFalse(result);
        }

        [Test]
        public void GivenInputArray_WhenItReachesForIntegersInMainInRightOrder_ThenReturnTrue()
        {
            // arrange
            int[] main = { 4, 2, 7, -1, 7, 2, 18, 10, -4 };
            int[] input = { 4, 7, 10, -4 };

            // act
            var result = Subsequence.IsSubsequence(main, input);

            // assert
            Assert.IsTrue(result);
        }

        [Test]
        public void GivenInputArray_WhenItReachesForIntegersInMainInUnrightOrder_ThenReturnFalse()
        {
            // arrange
            int[] main = { 4, 2, 7, -1, 7, 2, 18, 10, -4 };
            int[] input = { 4, 18, -1, -4 };

            // act
            var result = Subsequence.IsSubsequence(main, input);

            // assert
            Assert.IsFalse(result);
        }

        [Test]
        public void GivenMainAndInputArray_WhenItsEmpty_ThenReturnFalse()
        {
            // arrange
            int[] main = { };
            int[] input = { };

            // act
            var result = Subsequence.IsSubsequence(main, input);

            // assert
            Assert.IsFalse(result);
        }

        [Test]
        public void GivenInputArray_WhenHasUnrecognizedIntegers_ThenReturnFalse()
        {
            // arrange
            int[] main = { 23, -2, 7, 17 };
            int[] input = { 23, -2, 7, 17, 8 };

            // act
            var result = Subsequence.IsSubsequence(main, input);

            // assert
            Assert.IsFalse(result);
        }

        [Test]
        public void GivenInputArray_WhenItReachesForUnrecognizedIntegerInMain_ThenReturnFalse()
        {
            // arrange
            int[] main = { 8, -12, 12, 43 };
            int[] input = { 3 };

            // act
            var result = Subsequence.IsSubsequence(main, input);

            // assert
            Assert.IsFalse(result);
        }
    }
}
