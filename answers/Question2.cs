namespace AOC2022;

public class Question2 : IAnswer
{
    public enum WinState
    {
        LOSS = 0,
        DRAW = 3,
        WIN = 6
    }

    public enum Shape
    {
        ROCK = 1,
        PAPER,
        Scissors
    }

    public Dictionary<char, Shape> shapeMap = new Dictionary<char, Shape>()
    {
        {'A', Shape.ROCK},
        {'B', Shape.PAPER},
        {'C', Shape.Scissors},
        {'X', Shape.ROCK},
        {'Y', Shape.PAPER},
        {'Z', Shape.Scissors}
    };

    public int ProcessAnswer()
    {
        var winMap = new Dictionary<char, Dictionary<char, WinState>>()
        {
            {'X', new Dictionary<char, WinState>(){
                {'A', WinState.DRAW},
                {'B', WinState.LOSS},
                {'C', WinState.WIN}
            }},
            {'Y', new Dictionary<char, WinState>(){
                {'A', WinState.WIN},
                {'B', WinState.DRAW},
                {'C', WinState.LOSS}
            }},
            {'Z', new Dictionary<char, WinState>(){
                {'A', WinState.LOSS},
                {'B', WinState.WIN},
                {'C', WinState.DRAW}
            }},
        };


        var lines = Util.LoadQuestionFile("question2.txt");
        int myTotalScore = 0;

        foreach (var line in lines)
        {
            var split = line.Split(" ");
            var opponentShape = Convert.ToChar(split[0]);
            var myShape = Convert.ToChar(split[1]);
            var state = winMap[myShape][opponentShape];

            switch (state)
            {
                case WinState.LOSS:
                    myTotalScore += (int)shapeMap[myShape];
                    break;
                case WinState.DRAW:
                    myTotalScore += (int)shapeMap[myShape] + (int)WinState.DRAW;
                    break;
                case WinState.WIN:
                    myTotalScore += (int)shapeMap[myShape] + (int)WinState.WIN;
                    break;

            }
        }

        return myTotalScore;
    }

    public int ProcessAnswer2()
    {
        var lines = Util.LoadQuestionFile("question2.txt");
        int myTotalScore = 0;

        var stateMap = new Dictionary<char, WinState>()
        {
            {'X', WinState.LOSS},
            {'Y', WinState.DRAW},
            {'Z', WinState.WIN}
        };

        foreach (var line in lines)
        {
            var split = line.Split(" ");
            var opponentShape = Convert.ToChar(split[0]);

            switch (stateMap[Convert.ToChar(split[1])])
            {
                case WinState.LOSS:
                    if (shapeMap[opponentShape] == Shape.ROCK)
                        myTotalScore += (int)Shape.Scissors + (int)WinState.LOSS;
                    else if (shapeMap[opponentShape] == Shape.PAPER)
                        myTotalScore += (int)Shape.ROCK + (int)WinState.LOSS;
                    else if (shapeMap[opponentShape] == Shape.Scissors)
                        myTotalScore += (int)Shape.PAPER + (int)WinState.LOSS;
                    break;
                case WinState.DRAW:
                    myTotalScore += (int)shapeMap[opponentShape] + (int)WinState.DRAW;
                    break;
                case WinState.WIN:
                    if (shapeMap[opponentShape] == Shape.ROCK)
                        myTotalScore += (int)Shape.PAPER + (int)WinState.WIN;
                    else if (shapeMap[opponentShape] == Shape.PAPER)
                        myTotalScore += (int)Shape.Scissors + (int)WinState.WIN;
                    else if (shapeMap[opponentShape] == Shape.Scissors)
                        myTotalScore += (int)Shape.ROCK + (int)WinState.WIN;
                    break;
            }
        }

        return myTotalScore;
    }

    public void PrintAnswer()
    {
        var answer = ProcessAnswer();
        Console.WriteLine($"Question 2: {answer} is the total score for following strategy guide");

        var answer2 = ProcessAnswer2();
        Console.WriteLine($"Question 2 Part 2: {answer2} is the total for the corrected guide");
    }
}