namespace Arrays
{
    public class Tournaments
    {
        public string WinnerOfTournament(List<Match> matches, int[] results)
        {
            var scores = new Dictionary<string, int>();

            for (int i = 0; i < matches.Count; i++)
            {
                var match = matches[i];
                var result = results[i];
                string winnerName;

                if (result == 1)
                {
                    winnerName = match.HomeTeam;
                }
                else
                {
                    winnerName = match.IncomingTeam;
                }

                if (scores.ContainsKey(winnerName))
                {
                    scores[winnerName] += 3;
                }
                else
                {
                    scores.Add(winnerName, 3);
                }
            }

            string absoluteWinner = string.Empty;
            int maxScore = -1;

            foreach (var entry in scores)
            {
                if (entry.Value > maxScore)
                {
                    maxScore = entry.Value;
                    absoluteWinner = entry.Key;
                }
            }

            return absoluteWinner;
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
    }
}