internal sealed class Challenge4 : IChallenge
{
    private readonly string[] _challengeData;

    public Challenge4()
    {
        _challengeData = Utils.GetChallengeFileLines("4");
    }

    public void HelpSantaPartOne()
    {
        var cards = new List<Card>();
        foreach(var challengeLine in _challengeData)
        {
            cards.Add(new Card(challengeLine));
        }

        Utils.PrintMessageForSanta("4", "1", cards.Sum(s => s.CardScore));
    }

    public void HelpSantaPartTwo()
    {
        throw new NotImplementedException();
    }
}