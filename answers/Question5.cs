namespace AOC2022;
using System.Text.RegularExpressions;

public class Question5 : IAnswer 
{
    public (Dictionary<int, Stack<char>> Map, List<string> Lines, int InputStart) BuildTowerMap()
    {
        var input = Util.LoadQuestionFile("question5.txt");

        // Build map including numberline, before instructions
        List<string> premap = new();
        foreach(var line in input) 
        {
            if(String.IsNullOrWhiteSpace(line)) 
            {
                break;
            }
            premap.Add(line);
        }

        // Get last digit of number line
        var totalStacksToCreate = premap.Last()
            .Trim()
            .Split("  ")
            .Select(x => Convert.ToInt32(x))
            .Last();

        // Remove Number Line
        premap.RemoveAt(premap.Count - 1);

        // Init Dictionary
        Dictionary<int, Stack<char>> map = new();
        for(int i = 1; i <= totalStacksToCreate; i++)
            map.Add(i, new());
        
        // Reverse through map input and build each stack -- FILO
        for(int i = premap.Count - 1; i >= 0; i--)
        {
            // Remove [] and replace missing char gap with symbol to denote it should be skipped
            var line = premap[i]
                .Replace("[", "")
                .Replace("]", "")
                .Replace("    ", " @");

            int stackToPlace = 1;
            for(int j = 0; j < line.Length; j++)
            {   
                if(line[j] == '@') 
                {
                    stackToPlace++;
                    continue;
                }

                if(char.IsLetter(line[j])) 
                {
                    map[stackToPlace].Push(line[j]);
                    stackToPlace++; 
                } 
            }
        }

        return (
            map, 
            input, 
            premap.Count + 2
        );
    }
    public string ProcessAnswer()
    {
        var (map, lines, inputStart) = BuildTowerMap();

        string numberRegex = @"move (\d+) from (\d+) to (\d+)";
        for(int i = inputStart; i < lines.Count; i++)
        {
            var found = Regex.Match(lines[i], numberRegex);
            
            int howManyToMove = Convert.ToInt32(found.Groups[1].Value);
            int src = Convert.ToInt32(found.Groups[2].Value);
            int dest = Convert.ToInt32(found.Groups[3].Value);

            var srcStackRef = map[src];
            var destStackRef = map[dest];

            for(int count = 0; count < howManyToMove; count++) 
            {
                var item = srcStackRef.Pop();
                destStackRef.Push(item);
            }
        }

        // Select top of all stacks
        string answer = string.Empty;
        foreach(var tower in map) 
        {
            answer += tower.Value.Pop();
        }

        return answer;
    }

    public string ProcessAnswer2() 
    {

        // TODO: PART 2

        return "";
    }

    public void PrintAnswer()
    {
        var answer = ProcessAnswer();
        Console.WriteLine($"Quesiton 5: top crates are - {answer}");

        var answer2 = ProcessAnswer();
        Console.WriteLine($"Question 5 Part 2: {answer2}");
    }
}