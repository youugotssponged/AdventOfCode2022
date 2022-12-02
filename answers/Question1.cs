namespace AOC2022;

public class Question1 : IAnswer
{
    public List<int> ProcessElves(){
        var lines = Util.LoadQuestionFile("Question1.txt");
        List<int> elves = new();

        int runningTotal = 0;

        for(int i = 0; i < lines.Count; i++)
        {
            if(String.IsNullOrWhiteSpace(lines[i]))
            {
                elves.Add(runningTotal);
                runningTotal = 0;
                continue;
            }

            runningTotal += Convert.ToInt32(lines[i]);
        }

        return elves;
    }

    public int ProcessAnswer() => ProcessElves().OrderByDescending(x => x).FirstOrDefault();
    public int ProcessAnswer2() => ProcessElves().OrderByDescending(x => x).Take(3).Sum();

    public void PrintAnswer()
    {
        var answer = ProcessAnswer();
        Console.WriteLine($"Question 1: {answer} is the most carried");

        var answer2 = ProcessAnswer2();
        Console.WriteLine($"Question 1 Part 2: {answer2} is the total carried by the top three.");
    }
}