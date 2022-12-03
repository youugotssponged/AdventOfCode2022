namespace AOC2022;

public class Question3 : IAnswer
{
    public char[] LowerCasePriorities = {
        'a', 'b', 'c', 'd',
        'e', 'f', 'g', 'h',
        'i', 'j', 'k', 'l',
        'm', 'n', 'o', 'p',
        'q', 'r', 's', 't',
        'u', 'v', 'w', 'x',
        'y', 'z'
    };

    public int ProcessAnswer()
    {
        var lines = Util.LoadQuestionFile("question3.txt");
        List<char> DuplicateItems = new();

        foreach (var line in lines)
        {
            var backpackFirstSlot = line.Substring(0, line.Length / 2);
            var backpackSecondSlot = line.Substring(line.Length / 2);
            bool foundForLine = false;

            for (int i = 0; i < backpackFirstSlot.Length; i++)
            {
                if (foundForLine) break;

                for (int j = 0; j < backpackSecondSlot.Length; j++)
                {
                    if (backpackFirstSlot[i] == backpackSecondSlot[j])
                    {
                        DuplicateItems.Add(backpackSecondSlot[j]);
                        foundForLine = true;
                        break;
                    }
                }
            }
        }

        return FindTotal(DuplicateItems);
    }

    public int ProcessAnswer2()
    {
        var lines = Util.LoadQuestionFile("question3.txt");
        List<char> DuplicateItems = new();

        for (int line_idx = 0; line_idx < lines.Count; line_idx += 3)
        {
            var backpackFirst = lines[line_idx];
            var backpackSecond = lines[line_idx + 1];
            var backpackThird = lines[line_idx + 2];
            bool foundForGroup = false;

            for (int i = 0; i < backpackFirst.Length; i++)
            {
                if (foundForGroup) break;
                for (int j = 0; j < backpackSecond.Length; j++)
                {
                    if (foundForGroup) break;
                    for (int k = 0; k < backpackThird.Length; k++)
                    {
                        if (
                            backpackFirst[i] == backpackSecond[j] 
                            && backpackFirst[i] == backpackThird[k] 
                            && backpackSecond[j] == backpackThird[k]
                        )
                        {
                            DuplicateItems.Add(backpackThird[k]);
                            foundForGroup = true;
                            break;
                        }
                    }
                }
            }
        }

        return FindTotal(DuplicateItems);
    }

    public int FindTotal(List<char> DuplicateItems)
    {
        int runningTotal = 0;
        foreach (var item in DuplicateItems)
        {
            if (char.IsUpper(item))
            {
                runningTotal += Array.IndexOf(LowerCasePriorities, char.ToLower(item)) + 27;
                continue;
            }

            int index = Array.IndexOf(LowerCasePriorities, item) + 1;
            runningTotal += index;
        }
        return runningTotal;
    }

    public void PrintAnswer()
    {
        var answer = ProcessAnswer();
        Console.WriteLine($"Question 3: {answer} is the sum of the priorities of those item types");

        var answer2 = ProcessAnswer2();
        Console.WriteLine($"Question 3 part 2: {answer2} is the sum of the priorities of those item types");
    }
}