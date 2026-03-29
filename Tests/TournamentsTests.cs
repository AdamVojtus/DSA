using Arrays;

namespace Tests
{
    public class TournamentsTests
    {
        [Test]
        public void GivenArrayAndTargetSum_WhenPairExists_ThenReturnTrue()
        {
            // arrange
            List<Match> matches = new List<Match>
            {
                new Match("TK", "CA"),
                new Match("MV", "TK"),
                new Match("CA", "MV")
            };

            int[] results = { 1, 0, 0 };

            // act
            var tournaments = new Tournaments();
            var result = tournaments.WinnerOfTournament(matches, results);

            // assert
            Assert.That(result, Is.EqualTo("TK"));
        }

        [Test]
        public void GivenArrayAndTargetSum_WhenIndexOutOfAllowed_ThenReturnFalse()
        {
            // arrange
            List<Match> matches = new List<Match>
            {
                new Match("TK", "CA"),
                new Match("MV", "TK"),
                new Match("CA", "MV")
            };

            int[] results = { -1, 0, 1 };

            // act & assert
            foreach (var match in matches)
            {
                Assert.Throws<ArgumentOutOfRangeException>(() => match.GetWinner(results[0]));
            }
        }
    }
}
