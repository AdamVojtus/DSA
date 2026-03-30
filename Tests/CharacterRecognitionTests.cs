namespace Tests
{
    public class CharacterRecognitionTests
    {
        private const string AvailableCharacters = "dcca";

        [Test]
        public void GivenValidExactMatch_WhenCheckingRecognition_ThenReturnsTrue()
        {
            // Arrange
            var possibleText = "acdc";

            // Act
            var result = Strings.CharacterRecognition.IsCharacterRecognized(AvailableCharacters, possibleText);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void GivenTextWithUnsupportedSpace_WhenCheckingRecognition_ThenReturnsFalse()
        {
            // Arrange
            var possibleText = "ac dc";

            // Act
            var result = Strings.CharacterRecognition.IsCharacterRecognized(AvailableCharacters, possibleText);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void GivenTextIsPartialSubset_WhenCheckingRecognition_ThenReturnsTrue()
        {
            // Arrange
            var possibleText = "acc";

            // Act
            var result = Strings.CharacterRecognition.IsCharacterRecognized(AvailableCharacters, possibleText);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void GivenTextWithUnsupportedUpperCase_WhenCheckingRecognition_ThenReturnsFalse()
        {
            // Arrange
            var possibleText = "acDc";

            // Act
            var result = Strings.CharacterRecognition.IsCharacterRecognized(AvailableCharacters, possibleText);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void GivenOutnumberedUniqueCharacter_WhenCheckingRecognition_ThenReturnsFalse()
        {
            // Arrange
            var possibleText = "acca";

            // Act
            var result = Strings.CharacterRecognition.IsCharacterRecognized(AvailableCharacters, possibleText);

            // Assert
            Assert.IsFalse(result);
        }
    }
}