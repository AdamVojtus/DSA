namespace Strings
{
    public class Synonyms
    {
        public string[][] AreSynonyms(List<string[]> synonymGroups)
        {
            var parentMap = new Dictionary<string, string>();

            string GetRoot(string word)
            {
                if (!parentMap.ContainsKey(word))
                {
                    parentMap[word] = word;
                }

                if (parentMap[word] != word)
                {
                    parentMap[word] = GetRoot(parentMap[word]);
                }

                return parentMap[word];
            }

            foreach (var group in synonymGroups)
            {
                if (group.Length == 0) continue;

                string root = GetRoot(group[0]);
                for (int i = 1; i < group.Length; i++)
                {
                    string rootParent = GetRoot(group[i]);
                    if (root != rootParent)
                    {
                        parentMap[rootParent] = root;
                    }
                }
            }

            return parentMap.Keys
                .GroupBy(GetRoot)
                .Select(group => group.ToArray())
                .ToArray();
        }
    }
}