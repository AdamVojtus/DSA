namespace Tests
{
    public class CharacterRecognitionTests
    {
        [Test]
        public void TestIsCharacterRecognized()
        {
            // Arrange
            var availableCharacters = "dcca";
            var possibleText1 = "acdc";
            var possibleText2 = "ac dc";
            var possibleText3 = "acc";
            var possibleText4 = "acDc";
            var possibleText5 = "acca";

            // Act & Assert
            Assert.IsTrue(CharacterRecognition.CharacterRecognition.IsCharacterRecognized(availableCharacters, possibleText1));
            Assert.IsFalse(CharacterRecognition.CharacterRecognition.IsCharacterRecognized(availableCharacters, possibleText2));
            Assert.IsTrue(CharacterRecognition.CharacterRecognition.IsCharacterRecognized(availableCharacters, possibleText3));
            Assert.IsFalse(CharacterRecognition.CharacterRecognition.IsCharacterRecognized(availableCharacters, possibleText4));
            Assert.IsFalse(CharacterRecognition.CharacterRecognition.IsCharacterRecognized(availableCharacters, possibleText5));
        }
    }
}
