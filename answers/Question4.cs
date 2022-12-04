namespace AOC2022;

public class Question4 : IAnswer
{
    public int ProcessAnswer()
    {
        var lines = Util.LoadQuestionFile("question4.txt");
        int totalAssignmentPairs = 0;

        foreach (var line in lines)
        {
            var group = line.Split(",");
            var firstRange = group[0].Split("-");
            var secondRange = group[1].Split("-");

            List<int> firstElfRange = new();
            for (int i = Convert.ToInt32(firstRange[0]); i <= Convert.ToInt32(firstRange[1]); i++)
            {
                firstElfRange.Add(i);
            }

            List<int> secondElfRange = new();
            for (int i = Convert.ToInt32(secondRange[0]); i <= Convert.ToInt32(secondRange[1]); i++)
            {
                secondElfRange.Add(i);
            }

            int totalToFullyContainFirst = firstElfRange.Count;
            int totalToFullyContainSecond = secondElfRange.Count;

            // Check first overlapping second
            int leftCovered = 0;
            foreach (var range in firstElfRange)
            {
                foreach (var s_range in secondElfRange)
                {
                    if (range == s_range)
                        leftCovered++;
                }
            }

            if (leftCovered == totalToFullyContainFirst)
            {
                totalAssignmentPairs++;
                continue;
            }

            // If we've made it here, check Second overlapping First
            int rightCovered = 0;
            foreach (var range in secondElfRange)
            {
                foreach (var f_range in firstElfRange)
                {
                    if (range == f_range)
                        rightCovered++;
                }
            }

            if (rightCovered == totalToFullyContainSecond)
            {
                totalAssignmentPairs++;
                continue;
            }
        }
        return totalAssignmentPairs;
    }

    public int ProcessAnswer2()
    {
        var lines = Util.LoadQuestionFile("question4.txt");
        int totalAssignmentPairs = 0;

        foreach (var line in lines)
        {
            var group = line.Split(",");
            var firstRange = group[0].Split("-");
            var secondRange = group[1].Split("-");

            List<int> firstElfRange = new();
            for (int i = Convert.ToInt32(firstRange[0]); i <= Convert.ToInt32(firstRange[1]); i++)
                firstElfRange.Add(i);
            
            List<int> secondElfRange = new();
            for (int i = Convert.ToInt32(secondRange[0]); i <= Convert.ToInt32(secondRange[1]); i++)
                secondElfRange.Add(i);

            bool hasOverlapped = false;
            foreach (var range in firstElfRange)
            {
                if (hasOverlapped) break;
                foreach (var s_range in secondElfRange)
                {
                    if (range == s_range)
                    {
                        hasOverlapped = true;
                        totalAssignmentPairs++;
                        break;
                    }
                }
            }

            if (!hasOverlapped)
            {
                foreach (var range in secondElfRange)
                {
                    if (hasOverlapped) break;
                    foreach (var f_range in firstElfRange)
                    {
                        if (range == f_range)
                        {
                            hasOverlapped = true;
                            totalAssignmentPairs++;
                            break;
                        }
                    }
                }
            }
        }
        return totalAssignmentPairs;
    }

    public void PrintAnswer()
    {
        var answer = ProcessAnswer();
        Console.WriteLine($"Question 4: {answer} is how many assignment pairs fully contain each other.");

        var answer2 = ProcessAnswer2();
        Console.WriteLine($"Question 4 part 2: {answer2} is how many assignment pairs overlap in general");
    }
}