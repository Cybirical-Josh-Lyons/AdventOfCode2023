internal class Challenge3 : IChallenge
{
    private readonly char[,] _challengeData;
    private readonly char[] _specialCharacters; 

    public Challenge3()
    {
        var fileData = Utils.GetChallengeFileLines("3");
        _challengeData = new char[fileData.Length, fileData.Length];
        int row = 0, column;

        foreach(var challengeLine in fileData)
        {
            column = 0;
            foreach(var character in challengeLine)
            {
                _challengeData[row, column] = character;
                column++;
            }

            row++;
        }
        _specialCharacters = new[] {'!', '@', '#', '$', '%', '^', '&', '*', '+', '/', '=', '-'};
    }

    public void HelpSantaPartOne()
    {
        /*
            Apparently the elves have an extremely odd
            way of storing part data.. We need to sum
            up the part numbers so that Santa can get the 
            correct information. Here is what we are going to do:
            1.) Create a 2d array of characters.
            2.) Search for any symbal (NaN excluding '.')
            3.) Look at the spaces surrounding the symbol for a number
            4.) Store the number off
            5.) Add em up
        */
        var partNumbers = new List<int>();

        for(var x = 0; x < _challengeData.GetLength(0); x++)
        {
            for(var y = 0; y < _challengeData.GetLength(1); y++)
            {
                // We have symbol
                if(!char.IsDigit(_challengeData[x,y]) && _specialCharacters.Contains(_challengeData[x,y]))
                {
                    partNumbers.AddRange(FindDigits(x, y));
                }
            }
        }

        Utils.PrintMessageForSanta("3", "1", partNumbers.Sum(x => x));
    }

    public void HelpSantaPartTwo()
    {
        throw new NotImplementedException();
    }

    private List<int> FindDigits(int startingRow, int startingColumn)
    {
        var partNumberList = new List<int>();
        var immediateGrid = new Grid(startingRow, startingColumn, _challengeData.GetLength(0));

        // If point contains a digit, we need to build out the numeric value
        foreach(var pointProp in immediateGrid.GetType().GetProperties())
        {
            var point = (Point?)pointProp.GetValue(immediateGrid) ?? throw new Exception("Point should not be null here.");
            partNumberList.Add(BuildDigit(point, immediateGrid, partNumberList));
        }

        return partNumberList;
    }

    private int BuildDigit(Point checkPoint, Grid currentGrid, List<int> currentList)
    {
        string potentialNumber = "";
        char currentChar;
        int startingNumericPoint, 
            endingNumericPoint,
            startingPoint = checkPoint.Y;

        if(!char.IsDigit(_challengeData[checkPoint.X, checkPoint.Y]))
            return 0;

        // Start going backwards
        while(startingPoint > 0)
        {
            currentChar = _challengeData[checkPoint.X, startingPoint];
            if(!char.IsDigit(currentChar)) break;
            startingPoint--;
        }

        startingNumericPoint = startingPoint;
        startingPoint = checkPoint.Y;

        // Now go forwards
        while(startingPoint < _challengeData.GetLength(0))
        {
            currentChar = _challengeData[checkPoint.X, startingPoint];
            if(!char.IsDigit(currentChar)) break;
            startingPoint++;
        }

        endingNumericPoint = startingPoint;

        for(var start = startingNumericPoint; start < endingNumericPoint; start++)
        {
           if (char.IsDigit(_challengeData[checkPoint.X, start])) potentialNumber += _challengeData[checkPoint.X, start];
        }

        var parsedNumber = int.Parse(potentialNumber);

        return currentList.Contains(parsedNumber) && Clashes(startingNumericPoint, endingNumericPoint, currentGrid) ? 0 : parsedNumber;
    }

    private static bool Clashes(int startIndex, int endIndex, Grid currentGrid)
    {
        var clashes = false;

        foreach(var pointProps in currentGrid.GetType().GetProperties())
        {
            var point = (Point?)pointProps.GetValue(currentGrid) ?? throw new Exception("Point should not be null here");

            if(point.Y > startIndex && point.Y < endIndex)
            {
                clashes = true;
                break;
            }
        }

        return clashes;
    }
}