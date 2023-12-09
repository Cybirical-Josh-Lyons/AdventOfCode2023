using System.Text.RegularExpressions;

internal partial class Card
{
    public List<int> CardNumbers {get; private set;}
    public List<int> WinningNumbers {get; private set;}
    public int CardScore {get; private set;}

    public Card(string cardRowData)
    {
        var cardAndNumbers = cardRowData.Split(':');
        var cardNumbersAndWinningNumbers = cardAndNumbers[1].Split('|');
        CardNumbers = new List<int>();
        WinningNumbers = new List<int>();
        CardNumbers.AddRange(MyRegex().Matches(input: cardNumbersAndWinningNumbers[0]).Select(x => int.Parse(x.Value)));
        WinningNumbers.AddRange(MyRegex().Matches(input: cardNumbersAndWinningNumbers[1]).Select(x => int.Parse(x.Value)));

        CalculateScore();
    }

    private void CalculateScore()
    {
        var matchList = WinningNumbers.Where(w => CardNumbers.Contains(w)).ToList();
        
        CardScore = (int)Math.Pow(2, matchList.Count - 1);
    }

    [GeneratedRegex("\\d+")]
    private static partial Regex MyRegex();
}