using System.Diagnostics;
using System.Globalization;

namespace HackerRankSolutions.CrosswordPuzzle
{
    public class CrosswordPuzzle
    {
        private record Slot(int FirstRow, int FirstCol, int LastRow, int LastCol, bool Horizontal);
        public static List<string> crosswordPuzzle(List<string> crossword, string words)
        {
            int n = crossword.Count;
            var wordsList = words.Split(';').ToList();
            var wordsByLength = new Dictionary<int, List<string>>();
            foreach (var word in wordsList)
            {
                if (!wordsByLength.ContainsKey(word.Length))
                {
                    wordsByLength[word.Length] = new List<string>();
                }
                wordsByLength[word.Length].Add(word);
            }

            var grid = crossword.Select(x => x.ToList()).ToList();            
            var horizontalSlots = FindSlots(grid, wordsByLength, true);
            var verticalSlots = FindSlots(grid, wordsByLength, false);
            var slots = horizontalSlots.Union(verticalSlots).ToList();
            var slotsDict = new Dictionary<int, List<Slot>>();
            foreach(var slot in slots)
            {
                int slotLength = (slot.FirstRow == slot.LastRow ? slot.LastCol - slot.FirstCol : slot.LastRow - slot.FirstRow) + 1;
                if (!slotsDict.ContainsKey(slotLength))
                {
                    slotsDict[slotLength] = new List<Slot>();
                }
                slotsDict[slotLength].Add(slot);
            }

            var (solution, _) = FillSlots(grid, wordsList, slotsDict);
            var result = solution.Select(x => new string(x.ToArray())).ToList();
            return result;
        }        

        private static (List<List<char>> grid, bool solved) FillSlots(List<List<char>> grid, List<string> remainingWords, Dictionary<int, List<Slot>> remainingSlotsDict)
        {
            if (remainingWords.Count == 0) return (grid, true);
            Debug.Assert(remainingWords.Count > 0);
            Debug.Assert(remainingSlotsDict.Values.SelectMany(x => x).Any());
            var nextWord = remainingWords.First();
            int wordLength = nextWord.Length;
            var compatibleSlots = remainingSlotsDict[wordLength];
            var remainingWordsMinus = remainingWords.Where(x => x != nextWord).ToList();
            foreach(var slot in compatibleSlots)
            {                
                var possibleGrid = WriteWord(grid, nextWord, slot);
                if (possibleGrid != null)
                {
                    var remainingSlotsDictMinus = new Dictionary<int, List<Slot>>(remainingSlotsDict);
                    remainingSlotsDictMinus[wordLength] = remainingSlotsDict[wordLength].Where(x => x != slot).ToList();
                    var candidate = FillSlots(possibleGrid, remainingWordsMinus, remainingSlotsDictMinus);
                    if (candidate.solved)
                    {
                        return candidate;
                    }
                }
                
            }
            return (grid, false);
        }

        private static List<List<char>>? WriteWord(List<List<char>> grid, string word, Slot slot)
        {
            var newGrid = grid.Select(x => new List<char>(x)).ToList();            
            int constIndex = slot.Horizontal ? slot.FirstRow : slot.FirstCol;
            int startVarIndex = slot.Horizontal ? slot.FirstCol : slot.FirstRow;
            int endVarIndex = slot.Horizontal ? slot.LastCol : slot.LastRow;
            int wordOffset = 0;
            for (int i = startVarIndex; i <= endVarIndex; i++)
            {
                int row = slot.Horizontal ? constIndex : i;
                int col = slot.Horizontal ? i : constIndex;
                if (newGrid[row][col] != '-' && newGrid[row][col] != word[wordOffset])
                {
                    return null;
                }
                newGrid[row][col] = word[wordOffset++];
            }
            return newGrid;
        }

        private static List<Slot> FindSlots(List<List<char>> grid, Dictionary<int, List<string>> wordsByLength, bool horizontal)
        {
            int n = grid.Count;
            var c = (int i, int j) => horizontal ? grid[i][j] : grid[j][i];
            var slots = new List<Slot>();

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n;)
                {
                    if (c(i, j) == '-')
                    {
                        int start = j;
                        while (j < n && c(i, j) == '-')
                        {
                            j++;
                        }
                        int end = j - 1;
                        var slotLength = end - start + 1;
                        if (wordsByLength.ContainsKey(slotLength))
                        {
                            int startRow = horizontal ? i : start;
                            int startCol = horizontal ? start : i;
                            int lastRow = horizontal ? i : end;
                            int lastCol = horizontal ? end : i;
                            Slot slot = new(startRow, startCol, lastRow, lastCol, horizontal);
                            slots.Add(slot);
                        }
                    }
                    else
                    {
                        j++;
                    }
                }
            }
            return slots;
        }

        public static void SolveInput()
        {
            List<string> crossword = new List<string>();

            for (int i = 0; i < 10; i++)
            {
                string crosswordItem = Console.ReadLine();
                crossword.Add(crosswordItem);
            }

            string words = Console.ReadLine();

            List<string> result = crosswordPuzzle(crossword, words);

            Console.WriteLine(String.Join("\n", result));
        }        
    }    
}
