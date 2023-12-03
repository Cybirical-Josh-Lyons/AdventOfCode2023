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
        _specialCharacters = new[] {'!', '@', '#', '$', '%', '^', '&', '*'};
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
                    // Now we need to check the surrounding elements
                    var surroundValues = from i in Enumerable.Range(x - 1, x + 1)
                                            from j in Enumerable.Range(y - 1, y + 1)
                                            where char.IsDigit(_challengeData[i, j])
                                            select _challengeData[i, j];
                                            
                    Console.WriteLine(string.Join(',', surroundValues));
                }
            }
        }

        Utils.PrintMessageForSanta("3", "1", partNumbers.Sum(x => x));
    }

    public void HelpSantaPartTwo()
    {
        throw new NotImplementedException();
    }
}