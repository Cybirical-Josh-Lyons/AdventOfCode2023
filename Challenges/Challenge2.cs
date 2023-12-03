internal class Challenge2 : IChallenge
{

    private readonly string[] _gameRecordsList;
    private readonly int RED_CUBE_COUNT = 12, 
        GREEN_CUBE_COUNT = 13, 
        BLUE_CUBE_COUNT = 14;

    public Challenge2()
    {
        _gameRecordsList = Utils.GetChallengeFileLines("2");
    }

    public void HelpSantaPartOne()
    {
        /*
            We need to help some elves figure out math!
            Good thing we are also bad at it... Lets learn together!
            The goal here is to get the games where results recorder
            were possible given the bag stats that we know of.
        */
        var parsedRecordsList = new List<GameModel>();

        foreach(var gameRecord in _gameRecordsList)
        {
            var gameModel = new GameModel(gameRecord);
            gameModel.WasGamePossible(RED_CUBE_COUNT, BLUE_CUBE_COUNT, GREEN_CUBE_COUNT);
            
            parsedRecordsList.Add(gameModel);
        }
        var games = parsedRecordsList.Where(w => w.GameWasPossible == true);

        var possibleGameIdSum = parsedRecordsList.FindAll(f => f.GameWasPossible == true).Sum(s => s.Id);
        Utils.PrintMessageForSanta("2", "1", possibleGameIdSum);
    }

    public void HelpSantaPartTwo()
    {
        /*
            We now need to now multipy by multiple the power of cubes. Or something...
            Idk. Math.
        */
        var parsedRecordsList = new List<GameModel>();

        foreach(var gameRecord in _gameRecordsList)
        {
            var gameModel = new GameModel(gameRecord);
            parsedRecordsList.Add(gameModel);
        }

        var countOfColorage = parsedRecordsList.Sum(s => s.RedCount.Max() * s.BlueCount.Max() * s.GreenCount.Max());
        Utils.PrintMessageForSanta("2", "2", countOfColorage);
    }
}
