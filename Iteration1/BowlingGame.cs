namespace Iteration1;

class BowlingGame
{
    private List<int> rolls = new List<int>();

    public void roll(int pins)
    {
        rolls.Add(pins);
    }

    public int calculateScore()
    {
        var totalScore= (
            this.calculateTotalPinesKnockedDown() +
            this.calculateSpareBonusPerFrame() +
            this.calculateStrikeBonusPerFrame()
        );

        int maxScoreAllowed = 300;
        if (totalScore > maxScoreAllowed)
        {
            return maxScoreAllowed;
        }
        
        return totalScore;
    }

    private int calculateStrikeBonusPerFrame()
    {
        var strikeBonus = 0;
        for (int i = 0; i < rolls.Count; i++)
        {
            bool isStrike = i + 2 < rolls.Count && rolls[i] == 10;
            if (isStrike)
            {
                strikeBonus += rolls[i + 1] + rolls[i + 2];
            }
        }
        
        return strikeBonus;
    }

    private int calculateSpareBonusPerFrame()
    {
        var spareBonus = 0;
        for (int i = 0; i < rolls.Count; i+=2)
        {
            bool isSpare = i + 2 < rolls.Count &&  rolls[i] + rolls[i + 1] == 10;
            if (isSpare)
            {
                spareBonus += rolls[i + 2];
            }
        }
        
        return spareBonus;
    }

    private int calculateTotalPinesKnockedDown()
    {
        return rolls.Sum();
    }
}