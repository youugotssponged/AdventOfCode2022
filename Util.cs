namespace AOC2022;

public class Util {
    private static string questionPath = "./questions/";
    public static List<string> LoadQuestionFile(string fileName)
    {
        string? line;
        List<string> lines = new();
        using var sr = new StreamReader(questionPath + fileName);

        try 
        {
            while((line = sr.ReadLine()) != null) 
            {
                lines.Add(line);
            }
        }
        catch(IOException ioex)
        {
            Console.WriteLine($"ERROR! : {ioex.Message}, FILE CORRUPT OR NON-EXISTANT");
            sr.Dispose();
            return Enumerable.Empty<string>().ToList();
        }
        catch (OutOfMemoryException omex)
        {
            Console.WriteLine($"ERROR! : {omex.Message}, FILE TOO BIG");
            sr.Dispose();
            return Enumerable.Empty<string>().ToList();
        }

        return lines;
    }
}