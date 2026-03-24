namespace CharacterRecognition
{
    public class CharacterRecognition
    {
        public static bool IsCharacterRecognized(string availableCharacters, string possibleText)
        {
            int[] counts = new int[256];

            for (int i = 0; i < availableCharacters.Length; i++)
            {
                counts[availableCharacters[i]]++;
            }

            for (int i = 0; i < possibleText.Length; i++)
            {
                char current = possibleText[i];

                if (counts[current] == 0)
                {
                    return false;
                }

                counts[current]--;
            }

            return true;
        }
    }
}