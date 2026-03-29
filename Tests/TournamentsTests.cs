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
    }
}
