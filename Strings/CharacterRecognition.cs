namespace Strings
{
    public class CharacterRecognition
    {
        public static bool IsCharacterRecognized(string availableCharacters, string possibleText)
        {
            var availableCharactersWithCount = new Dictionary<char, int>();

            for (int i = 0; i < availableCharacters.Length; i++)
            {
                var current = availableCharacters[i];
                if (availableCharactersWithCount.ContainsKey(current))
                    availableCharactersWithCount[current] += 1;
                else
                    availableCharactersWithCount[current] = 1;
            }

            for (int i = 0; i < possibleText.Length; i++)
            {
                var current = possibleText[i];

                if (!availableCharactersWithCount.TryGetValue(current, out int count) || count == 0)
                {
                    return false;
                }

                availableCharactersWithCount[current] = count - 1;
            }

            return true;
        }
    }
}