using FluentAssertions;

namespace Iteration1;

class BowlingGame
{
    
    public void roll(int pins)
    {
    }

    public int calculateScore()
    {
       return 0;
    }
}

/*
 TODO LIST:
 * (11)x20          --> 10 points
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
}