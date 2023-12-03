using System.Text.RegularExpressions;

sealed partial class GameModel
{
    public int Id {get; private set;}
    public List<int> BlueCount {get; private set;}
    public List<int> GreenCount {get; private set;}
    public List<int> RedCount {get; private set;}
    public bool GameWasPossible {get; private set;} = false;

    public GameModel(string gameRecord)
    {
        BlueCount = new List<int>();
        GreenCount = new List<int>();
        RedCount = new List<int>();

        var gameRecordSplit = gameRecord.Split(':');
        var colorCountRecords = gameRecordSplit[1].Split(';');

        Id = int.Parse(MyRegex().Match(gameRecordSplit[0]).Value);

        foreach(var colorCountRecord in colorCountRecords)
        {
            var colorSplit = colorCountRecord.Split(',');
            foreach(var colorStr in colorSplit)
            {
                var potentialColorCount = MyRegex().Match(colorStr).Value;
                if(!string.IsNullOrEmpty(potentialColorCount)) 
                {
                    var colorCount = int.Parse(potentialColorCount);
                    if(colorStr.Contains("green"))
                        GreenCount.Add(colorCount);
                    else if (colorStr.Contains("blue"))
                        BlueCount.Add(colorCount);
                    else if (colorStr.Contains("red"))
                        RedCount.Add(colorCount);
                }
                else
                {
                    if(colorStr.Contains("green"))
                        GreenCount.Add(0);
                    else if (colorStr.Contains("blue"))
                        BlueCount.Add(0);
                    else if (colorStr.Contains("red"))
                        RedCount.Add(0);
                }
            }
        }
    }

    public void WasGamePossible(int redCount, int blueCount, int greenCount)
    {
        var redPossible = RedCount.Count(w => w > redCount);
        var bluePossible = BlueCount.Count(w => w > blueCount);
        var greenPossible = GreenCount.Count(w => w > greenCount);

        GameWasPossible = redPossible == 0 && bluePossible == 0 && greenPossible == 0;
    }

    [GeneratedRegex("\\d+")]
    private static partial Regex MyRegex();
}