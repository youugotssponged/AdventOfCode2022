namespace AOC2022;

public class Question3 : IAnswer
{
    public int ProcessAnswer()
    {
        char[] LowerCasePriorities = {
            'a', 'b', 'c', 'd', 
            'e', 'f', 'g', 'h', 
            'i', 'j', 'k', 'l', 
            'm', 'n', 'o', 'p', 
            'q', 'r', 's', 't', 
            'u', 'v', 'w', 'x', 
            'y', 'z' 
        };

        var lines = Util.LoadQuestionFile("question3.txt");
        List<char> DuplicateItems = new();

        foreach(var line in lines)
        {
            var backpackFirstSlot = line.Substring(0, line.Length / 2);
            var backpackSecondSlot = line.Substring(line.Length / 2);
            bool foundForLine = false;

            for(int i = 0; i < backpackFirstSlot.Length; i++)
            {
                if(foundForLine) break;

                for(int j = 0; j < backpackSecondSlot.Length; j++)
                {
                    if(backpackFirstSlot[i] == backpackSecondSlot[j]) 
                    {
                        DuplicateItems.Add(backpackSecondSlot[j]);
                        foundForLine = true;
                        break;
                    }
                }
            }
        }

        int runningTotal = 0;
        foreach(var item in DuplicateItems)
        {
            if(char.IsUpper(item))
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
    }
}