using Arrays;

namespace Tests
{
    public class TournamentsTests
    {
        [Test]
        public void WhenGivenTeam_AndIsAtHome_ThenReturnTrue()
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
        public void WhenGivenTournament_ThenReturnCorrectWinner()
        {
            List<Match> matches = new List<Match>
            {
                new Match("a", "b"),
                new Match("b", "c"),
                new Match("c", "a")
            };

            int[] results1 = { 1, 0, 1 };
            int[] results2 = { 0, 0, 1 };
            int[] results3 = { 1, 1, 0 };
            int[] results4 = { 0, 1, 0 };

            var tournaments = new Tournaments();
            var res1 = tournaments.WinnerOfTournament(matches, results1);
            var res2 = tournaments.WinnerOfTournament(matches, results2);
            var res3 = tournaments.WinnerOfTournament(matches, results3);
            var res4 = tournaments.WinnerOfTournament(matches, results4);

            Assert.That(res1, Is.EqualTo("c"));
            Assert.That(res2, Is.EqualTo("c"));
            Assert.That(res3, Is.EqualTo("a"));
            Assert.That(res4, Is.EqualTo("b"));
        }
    }
}