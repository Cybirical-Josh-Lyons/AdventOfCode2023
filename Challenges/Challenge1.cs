internal class Challenge1 : IChallenge
{
    public void HelpSantaPartOne() 
    {
        /* For the day 1 challenge, we 
            need to sum up the values within the 
            document. Each line is the sum of the first and last digit instance
            on each line. That is the coordinate for that document.    
        */

        // Get text file
        var coordinateList = new List<int>();
        var coordinatesRaw = File.ReadAllText("./TestFiles/Challenge1.txt").Split('\n');
        foreach(var coordinate in coordinatesRaw) 
        {
            var coordinateDigit = int.Parse($"{FindFirstCoordinate(coordinate)}{FindLastRowCoordinate(coordinate)}");
            coordinateList.Add(coordinateDigit);
        }

        Console.WriteLine($"Cooridnate for Santa (Day 1 Part 1 Challenge): {SumAllRowCoordinates(coordinateList)}");
    }

    public void HelpSantaPartTwo()
    {
        /* Turns out we was wrong on the coords bois.
            To get the real answer, we need to fix this bad data
            that the snow elves gave us. Each line actually has
            a number spelled out and we need to figure out what the first
            and last number actually is. So now, it could be a digit OR
            a string value representing a number.    
        */

        // Get text file

        var coordinateList = new List<int>();
        var coordinatesRaw = File.ReadAllText("./TestFiles/Challenge1.txt").Split('\n');
        var knownDigits = new List<KeyValuePair<string, int>>
        {
            new("one", 1),
            new("two", 2),
            new("three", 3),
            new("four", 4),
            new("five", 5),
            new("six", 6),
            new("seven", 7),
            new("eight", 8),
            new("nine", 9)
        };

        foreach(var coordinate in coordinatesRaw)
        {
            var coordinateDigit = int.Parse($"{FindFirstCoordinate(coordinate, knownDigits)}{FindLastRowCoordinate(coordinate, knownDigits)}");
            coordinateList.Add(coordinateDigit);
        }

        Console.WriteLine($"Coordinate for Santa (Day 1 Part 2 Challenge): {SumAllRowCoordinates(coordinateList)}");
    }

    static private string FindFirstCoordinate(string rowCoordinates) 
    {
        var potentialDigit = rowCoordinates.FirstOrDefault(c => int.TryParse(c.ToString(), out var intResult)).ToString();
        if(string.IsNullOrEmpty(potentialDigit))
            return "0";

        else
            return potentialDigit;
    }

    static private string FindLastRowCoordinate(string rowCoordinates)
    {
        var potentialDigit = rowCoordinates.LastOrDefault(c => int.TryParse(c.ToString(), out var intResult)).ToString();
        if(string.IsNullOrEmpty(potentialDigit))
            return "0";
        
        else
            return potentialDigit;
    }

    static private string FindFirstCoordinate(string rowCoordinates, List<KeyValuePair<string, int>> knownDigits)
    {
        // First, find the first digit (if any) then find the first 'string' digit if any, then compare string indices
        var foundDigit = "0";
        var potentialFoundDigit = FindFirstCoordinate(rowCoordinates);
        var potentialFoundStringDigit = knownDigits[0];

        foreach(var digit in knownDigits)
        {
            if(!rowCoordinates.Contains(potentialFoundStringDigit.Key, StringComparison.CurrentCulture) || rowCoordinates.Contains(digit.Key) 
                && rowCoordinates.IndexOf(digit.Key) < rowCoordinates.IndexOf(potentialFoundStringDigit.Key))
            {
                potentialFoundStringDigit = digit;
            }
        }

        var isPotentialFoundDigitNullOrEmpty = string.IsNullOrEmpty(potentialFoundDigit);
        var isPotentialFoundStringDigitNotThere = rowCoordinates.IndexOf(potentialFoundStringDigit.Key);

        if(isPotentialFoundDigitNullOrEmpty && isPotentialFoundStringDigitNotThere != -1)
        {
            foundDigit = potentialFoundStringDigit.Value.ToString(); // Yeah I know, but I am lazy...
        }
        else if(!isPotentialFoundDigitNullOrEmpty && isPotentialFoundStringDigitNotThere == -1) 
        {
            foundDigit = potentialFoundDigit;
        }
        else if(!isPotentialFoundDigitNullOrEmpty && isPotentialFoundStringDigitNotThere != -1) 
        {
            foundDigit = rowCoordinates.IndexOf(potentialFoundDigit) < rowCoordinates.IndexOf(potentialFoundStringDigit.Key) ?
                potentialFoundDigit : potentialFoundStringDigit.Value.ToString();
        }

        return foundDigit;
    }

    static private string FindLastRowCoordinate(string rowCoordinates, List<KeyValuePair<string, int>> knownDigits)
    {
        // First, find the last digit (if any) then find the last 'string' digit if any, then compare string indices
        var foundDigit = "0";
        var potentialFoundDigit = FindLastRowCoordinate(rowCoordinates);
        var potentialFoundStringDigit = knownDigits[0];

        foreach(var digit in knownDigits)
        {
            if(!rowCoordinates.Contains(potentialFoundStringDigit.Key, StringComparison.CurrentCulture) || rowCoordinates.Contains(digit.Key) 
                && rowCoordinates.LastIndexOf(digit.Key) > rowCoordinates.LastIndexOf(potentialFoundStringDigit.Key))
            {
                potentialFoundStringDigit = digit;
            }
        }

        var isPotentialFoundDigitNullOrEmpty = string.IsNullOrEmpty(potentialFoundDigit);
        var isPotentialFoundStringDigitNotThere = rowCoordinates.LastIndexOf(potentialFoundStringDigit.Key);

        if(isPotentialFoundDigitNullOrEmpty && isPotentialFoundStringDigitNotThere != -1)
        {
            foundDigit = potentialFoundStringDigit.Value.ToString(); // Yeah I know, but I am lazy...
        }
        else if(!isPotentialFoundDigitNullOrEmpty && isPotentialFoundStringDigitNotThere == -1) 
        {
            foundDigit = potentialFoundDigit;
        }
        else if(!isPotentialFoundDigitNullOrEmpty && isPotentialFoundStringDigitNotThere != -1) 
        {
            foundDigit = rowCoordinates.LastIndexOf(potentialFoundDigit) > rowCoordinates.LastIndexOf(potentialFoundStringDigit.Key) ?
                potentialFoundDigit : potentialFoundStringDigit.Value.ToString();
        }

        return foundDigit;
    }
    
    static private int SumAllRowCoordinates(List<int> rowCoordinates)
    {
        return rowCoordinates.Sum(x => x);
    }
}