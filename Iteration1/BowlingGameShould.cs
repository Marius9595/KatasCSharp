using FluentAssertions;

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
        return (
            this.calculateTotalPinesKnockedDown() +
            this.calculateSpareBonus()+
            this.calculateStrikeBonus()
            );
    }

    private int calculateStrikeBonus()
    {
        int bonus = 0;
        for (int i = 0; i < rolls.Count; i+=3)
        {
            if (rolls[i] == 10)
            {
                bonus += rolls[i + 1] + rolls[i + 2];
            }
        }
        return bonus;
    }

    private int calculateSpareBonus()
    {
        int bonus = 0;
        for (int i = 0; i < rolls.Count; i+= 2)
        {
            if (rolls[i] + rolls[i + 1] == 10)
            {
                bonus += rolls[i + 2];
            }
        }
        return bonus;
    }

    private int calculateTotalPinesKnockedDown()
    {
        return rolls.Sum();
    }
}

/*
 TODO LIST:
 * 5/ 5- (--)x8     --> 20 points
 *  X 23 (--)x8      --> 20 points
 * (X)x12           --> 300 points
 * (5/)x10 5        --> 150 points
 * (8/)x10 8        --> 180 points
 */

public class BowlingGameShould
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void calculate_the_score_where_no_pins_have_been_knocked_down()
    {
        var game = new BowlingGame();
        for (int i = 0; i < 20; i++)
        {
            game.roll(0);
        }

        game.calculateScore().Should().Be(0);
    }
    
    [Test]
    public void calculate_the_score_where_in_all_rolls_all_pines_were_not_knocked_down()
    {
        var game = new BowlingGame();
        for (int i = 0; i < 20; i++)
        {
            game.roll(1);
        }

        game.calculateScore().Should().Be(20);
    }
    
    [Test]
    public void calculate_the_score_when_spare_and_some_pines_are_knocked_down_in_the_following_roll()
    {
        var game = new BowlingGame();
        
        game.roll(5);
        game.roll(5);
        game.roll(5);
        for (int i = 0; i < 17; i++)
        {
            game.roll(0);
        }

        game.calculateScore().Should().Be(20);
    }
    
    [Test]
    public void calculate_the_score_when_spare_and_not_all_pines_were_knocked_down_in_the_two_following_rolls()
    {
        var game = new BowlingGame();
        
        game.roll(10);
        game.roll(2);
        game.roll(3);
        for (int i = 0; i < 17; i++)
        {
            game.roll(0);
        }

        game.calculateScore().Should().Be(20);
    }
}