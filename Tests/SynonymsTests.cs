namespace Tests
{
    public class SynonymsTests
    {
        [Test]
        public void GivenList_WhenSynonymsExists_ThenReturnCorrectMergedGroup()
        {
            // arrange
            var synonymGroups = new List<string[]>
            {
                new[] { "car", "automobile" },
                new[] { "automobile", "vehicle" },
                new[] { "happy", "joyful" },
                new[] { "joyful", "glad" },
                new[] { "sad", "unhappy" }
            };

            // act
            var result = new Strings.Synonyms().AreSynonyms(synonymGroups);

            // assert
            var expected = new string[][]
            {
                ["car", "automobile", "vehicle"],
                ["happy", "joyful", "glad"],
                ["sad", "unhappy"]
            };

            Assert.That(result, Is.EquivalentTo(expected));
        }

        [Test]
        public void GivenList_WhenMoreSynonymsExists_ThenReturnCorrectMergedGroup()
        {
            // arrange
            var synonymGroups = new List<string[]>
            {
                new[] { "car", "automobile", "vehicle" },
                new[] { "automobile", "vehicle" },
                new[] { "vehicle", "transport" },
                new[] { "happy", "joyful" },
                new[] { "joyful", "glad" },
                new[] { "sad", "unhappy" }
            };

            // act
            var result = new Strings.Synonyms().AreSynonyms(synonymGroups);

            // assert
            var expected = new string[][]
            {
                ["car", "automobile", "vehicle", "transport"],
                ["happy", "joyful", "glad"],
                ["sad", "unhappy"]
            };

            Assert.That(result, Is.EquivalentTo(expected));
        }

        [Test]
        public void GivenList_WhenNoSynonymsExists_ThenReturnOriginalGroups()
        {
            // arrange
            var synonymGroups = new List<string[]>
            {
                new[] { "car", "automobile" },
                new[] { "happy", "joyful" },
                new[] { "sad", "unhappy " }
            };

            // act
            var result = new Strings.Synonyms().AreSynonyms(synonymGroups);

            // assert
            Assert.That(result, Is.EquivalentTo(synonymGroups));
        }
    }
}
