namespace AOC2022;

using System.Reflection;

public class Program 
{
    public static void Main(String[] args) 
    { 
        var assembly = Assembly.GetExecutingAssembly();
        var types = AppDomain.CurrentDomain
            .GetAssemblies()
            .SelectMany(x => x.GetTypes())
            .Where(x => typeof(IAnswer).IsAssignableFrom(x))
            .OrderBy(x => x.FullName);

        foreach(var type in types)
        {
            if(type.Name == "IAnswer") continue;
            dynamic instance = Activator.CreateInstance(type) ?? new Object();
            instance.GetType()?.GetMethod("PrintAnswer")?.Invoke(instance, null);
            Console.WriteLine();
        }
    }
}