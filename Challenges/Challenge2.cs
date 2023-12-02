internal class Challenge2 : IChallenge
{
    private readonly int RED_CUBE_COUNT = 12, 
        GREEN_CUBE_COUNT = 13, 
        BLUE_CUBE_COUNT = 14;

    public void HelpSantaPartOne()
    {
        /*
            We need to help some elves figure out math!
            Good thing we are also bad at it... Lets learn together!
            The goal here is to get the games where results recorder
            were possible given the bag stats that we know of.
        */
        
        // Get text file
        var gameRecordsList = File.ReadAllLines("./TestFiles/Challenge2.txt");
        var parsedRecordsList = new List<GameModel>();

        foreach(var gameRecord in gameRecordsList)
        {
            var gameModel = new GameModel(gameRecord);
            gameModel.WasGamePossible(RED_CUBE_COUNT, BLUE_CUBE_COUNT, GREEN_CUBE_COUNT);
            
            parsedRecordsList.Add(gameModel);
        }
        var games = parsedRecordsList.Where(w => w.GameWasPossible == true);

        var possibleGameIdSum = parsedRecordsList.FindAll(f => f.GameWasPossible == true).Sum(s => s.Id);
        Console.WriteLine($"The ids of all possible games for Santa (Day 2 Part 1 Challenge): {possibleGameIdSum}");
    }

    public void HelpSantaPartTwo()
    {
        throw new NotImplementedException();
    }
}