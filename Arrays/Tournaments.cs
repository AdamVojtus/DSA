namespace Arrays
{
    public class Tournaments
    {
        public string WinnerOfTournament(List<Match> matches, int[] results)
        {
            var allMatchesResults = new AllMatchesResults();

            for (int i = 0; i < matches.Count; i++)
            {
                var match = matches[i];
                var resultIndex = results[i];

                var winnerName = match.GetWinner(resultIndex);
                allMatchesResults.WinnerOfCurrentMatch(winnerName);
            }

            return allMatchesResults.GetAbsoluteWinner();
        }

        public class AllMatchesResults
        {
            private readonly Dictionary<string, int> _values = new();

            public void WinnerOfCurrentMatch(string teamName)
            {
                if (_values.ContainsKey(teamName))
                {
                    _values[teamName] += 1;
                }
                else
                {
                    _values.Add(teamName, 1);
                }
            }

            public string GetAbsoluteWinner()
            {
                var result = _values.MaxBy(x => x.Value).Key;
                return result;
            }
        }
    }

    public class Match
    {
        public string HomeTeam { get; }
        public string IncomingTeam { get; }

        public Match(string homeTeam, string incomingTeam)
        {
            HomeTeam = homeTeam ?? throw new ArgumentNullException(nameof(homeTeam));
            IncomingTeam = incomingTeam ?? throw new ArgumentNullException(nameof(incomingTeam));
        }

        public string GetWinner(int index)
        {
            if (index != 0 && index != 1)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }

            if (index == 1)
            {
                return HomeTeam;
            }
            else
            {
                return IncomingTeam;
            }
        }
    }
}