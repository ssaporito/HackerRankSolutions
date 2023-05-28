using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankSolutions.ClimbingTheLeaderboard
{
    public class ClimbingTheLeaderboard
    {        
        public static List<int> ClimbingLeaderboard(List<int> scores, List<int> player)
        {
            int[] resultArray = new int[player.Count];
            var rankings = GetCurrentRankings(scores);            
            int scoreIndex = 0;
            for (int i = player.Count - 1; i >= 0; i--)
            {                               
                int ranking = FitScore(scores, rankings, player[i], ref scoreIndex);
                resultArray[i] = ranking;
            }
            return resultArray.ToList();
        }

        public static int FitScore(List<int> scores, List<int> rankings, int playerScore, ref int scoreIndex)
        {
            int ranking;
            while (playerScore < scores[scoreIndex] && scoreIndex + 1 < scores.Count)
            {
                scoreIndex++;
            }

            if (playerScore == scores[scoreIndex])
            {
                ranking = rankings[scoreIndex];
            }
            else if (playerScore > scores[scoreIndex])
            {
                ranking = scoreIndex == 0 ? 1 : rankings[scoreIndex];                
            }
            else // player has lowest score
            {
                ranking = rankings[scoreIndex] + 1;
            }
            return ranking;
        }

        public static List<int> GetCurrentRankings(List<int> scores)
        {
            List<int> rankings = new(scores.Count);
            int currentScore = int.MaxValue;
            int currentRanking = 0;
            foreach(var score in scores)
            {
                if (score < currentScore)
                {
                    currentScore = score;
                    currentRanking++;
                }
                rankings.Add(currentRanking);
            }
            return rankings;
        }        

        public static (List<int> ranked, List<int> player) ReadInput(string input)
        {
            var lines = input.Split("\r\n");
            int rankedCount = Convert.ToInt32(lines[0].Trim());

            List<int> ranked = lines[1].TrimEnd().Split(' ').ToList().Select(rankedTemp => Convert.ToInt32(rankedTemp)).ToList();

            int playerCount = Convert.ToInt32(lines[2].Trim());

            List<int> player = lines[3].TrimEnd().Split(' ').ToList().Select(playerTemp => Convert.ToInt32(playerTemp)).ToList();
            
            return (ranked, player);
        }

        public static string ResultToString(List<int> result)
        {
            return string.Join("\r\n", result);
        }

        public static List<int> StringToResult(string resultString)
        {
            return resultString.Split("\r\n").Select(s => Convert.ToInt32(s)).ToList();
        }
    }
}
