namespace Tests
{
    public class ArraySumariztionTests
    {
        [Test]
        public void GivenArrayAndTargetSum_WhenPairExists_ThenReturnTrue()
        {
            // arrange
            int[] input = { 6, 2, -1, 7, 4 };
            int targetSum = 6;

            // act
            bool result = Arrays.ArraySumarization.DoesArrayContainsTwoNumbersSum(input, targetSum);

            // assert
            Assert.That(result, Is.True);
        }

        [Test]
        public void GivenArrayAndTargetSum_WhenPairDoesNotExist_ThenReturnFalse()
        {
            // arrange
            int[] input = { 1, 2, 3, 4, 5 };
            int targetSum = 10;

            // act
            bool result = Arrays.ArraySumarization.DoesArrayContainsTwoNumbersSum(input, targetSum);

            // assert
            Assert.That(result, Is.False);
        }
    }
}
