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
    [Fact]
    public void display_the_value_of_a_valid_coin_inserted_when_it_is_the_first_one()
    {
        var displayMock = Substitute.For<DigitalDisplay>();
        var coinSelectorMock = Substitute.For<CoinSelector>();
        var coin = new { weight = 5, diameter = 0.835 };
        coinSelectorMock.identifyCoin(coin).Returns(Coin.Nickle);
        var vendingMachine = new VendingMachine(
            displayMock,
            coinSelectorMock
        );
        
        vendingMachine.acceptCoin(coin);

        coinSelectorMock.Received().identifyCoin(coin);
        displayMock.Received().show("0.05");
    }
}