internal static class Utils
{
    static public string[] GetChallengeFileLines(string challengeDayArg)
    {
        return File.ReadAllLines($"./TestFiles/Challenge{challengeDayArg}.txt");
    }

    static public string GetChallengeFileString(string challengeDayArg)
    {
        return File.ReadAllText($"./TestFiles/Challenge{challengeDayArg}.txt");
    }

    static public void PrintMessageForSanta(string challengeDayArg, string challengePart, object message)
    {
        Console.WriteLine($"The message for santa regarding this challenge (Day {challengeDayArg} Part {challengePart}): {message}");
    }
}