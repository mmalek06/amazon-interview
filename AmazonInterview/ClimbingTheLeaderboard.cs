using System.Collections.Generic;

namespace AmazonInterview {
    // https://www.hackerrank.com/challenges/climbing-the-leaderboard/problem
    // var result1 = ClimbingTheLeaderboard.ClimbingLeaderboard(
    // new List<int> { 100, 90, 90, 80, 75, 60 },
    // new List<int> { 50, 65, 77, 90, 102 }); // 6 5 4 2 1
    // var result2 = ClimbingTheLeaderboard.ClimbingLeaderboard(
    //     new List<int> { 100, 100, 50, 40, 40, 20, 10 },
    //     new List<int> { 5, 25, 50, 120 }); // 6 4 2 1
    public static class ClimbingTheLeaderboard {
        public static List<int> ClimbingLeaderboard(List<int> ranked, List<int> player) {
            var scoresMap = GetScoresMap(ranked);
            var result = new List<int>(ranked.Count);
            var indexLow = 0;
            var indexHigh = ranked.Count - 1;

            for (var i = 0; i < player.Count; i++) {
                var currentScore = player[i];
                var rank = Rank(indexLow, indexHigh, currentScore, ranked, scoresMap);

                result.Add(rank);
            }

            return result;
        }

        private static int Rank(int indexLow, int indexHigh, int currentScore, List<int> ranked, Dictionary<int, int> scoresMap) {
            do {
                var x = (indexHigh + indexLow) / 2;
                var goLeft = currentScore >= ranked[x];

                if (goLeft) {
                    if (indexHigh == x)
                        indexHigh = indexLow;
                    else
                        indexHigh = x;
                } else {
                    if (indexLow == x)
                        indexLow = indexHigh;
                    else
                        indexLow = x;
                }
            } while (indexHigh != indexLow);

            var oponentScore = ranked[indexHigh];
            var oponentRank = scoresMap[oponentScore];

            if (currentScore == oponentScore)
                return oponentRank;
            if (currentScore < oponentScore)
                return oponentRank + 1;
            if (currentScore > oponentScore && oponentRank == 1)
                return 1;
            if (currentScore > oponentScore)
                return oponentRank;

            return 0;
        }

        private static Dictionary<int, int> GetScoresMap(List<int> ranked) {
            var scoresMap = new Dictionary<int, int>();
            var index = 1;

            foreach (var score in ranked) {
                if (scoresMap.ContainsKey(score))
                    continue;

                scoresMap[score] = index;
                index++;
            }

            return scoresMap;
        }
    }
}
