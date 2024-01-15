using FsCheck;
using NSubstitute;

namespace VendingMachineKata;

public class DigitalDisplay
{
    public virtual void show(string message)
    {
        throw new NotImplementedException();
    }
}

public enum Coin
{
    Nickle = 5
}

public class CoinSelector
{
    public virtual Coin identifyCoin(object coin)
    {
        throw new NotImplementedException();
    }
}

public class VendingMachineShould
{
    [Theory]
    [InlineData(5, 0.835, Coin.Nickle, "0.05")]
    public void display_the_value_of_a_valid_coin_inserted_when_it_is_the_first_one(
        decimal weight,
        decimal diameter,
        Coin coinIdentifiedExpected,
        string messageToDisplayExpected
    )
    {
        var displayMock = Substitute.For<DigitalDisplay>();
        var coinSelectorMock = Substitute.For<CoinSelector>();
        var coin = new { weight = weight, diameter = diameter };
        coinSelectorMock.identifyCoin(coin).Returns(coinIdentifiedExpected);
        var vendingMachine = new VendingMachine(
            displayMock,
            coinSelectorMock
        );
        
        vendingMachine.acceptCoin(coin);

        coinSelectorMock.Received().identifyCoin(coin);
        displayMock.Received().show(messageToDisplayExpected);
    }
}