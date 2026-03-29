using NUnit.Framework;

namespace Tests
{
    public class CharacterRecognitionTests
    {
        private const string AvailableCharacters = "dcca";

        [Test]
        public void IsCharacterRecognized_ValidExactMatch_ReturnsTrue()
        {
            // Arrange
            var possibleText = "acdc";

            // Act
            var result = Strings.CharacterRecognition.IsCharacterRecognized(AvailableCharacters, possibleText);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void IsCharacterRecognized_TextContainsUnsupportedSpace_ReturnsFalse()
        {
            // Arrange
            var possibleText = "ac dc";

            // Act
            var result = Strings.CharacterRecognition.IsCharacterRecognized(AvailableCharacters, possibleText);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void IsCharacterRecognized_TextIsPartialSubset_ReturnsTrue()
        {
            // Arrange
            var possibleText = "acc";

            // Act
            var result = Strings.CharacterRecognition.IsCharacterRecognized(AvailableCharacters, possibleText);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void IsCharacterRecognized_TextIncludesUnsupportedUpperCase_ReturnsFalse()
        {
            // Arrange
            var possibleText = "acDc";

            // Act
            var result = Strings.CharacterRecognition.IsCharacterRecognized(AvailableCharacters, possibleText);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void IsCharacterRecognized_OutnumberedUniqueCharacter_ReturnsFalse()
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