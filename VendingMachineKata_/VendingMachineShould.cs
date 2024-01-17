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
    Nickle = 5,
    Dime = 10,
    Quarter = 25
    
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
    [InlineData(5.00, 21.21, Coin.Nickle, "0.05")]
    [InlineData(2.26, 17.91, Coin.Dime, "0.10")]
    [InlineData(5.67, 24.26, Coin.Quarter, "0.25")]
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
    
    [Fact]
    public void update_the_display_when_consecutive_valid_coins_are_inserted_showing_the_total_amount_of_money_after_each_coin_inserted()
    {
        var displayMock = Substitute.For<DigitalDisplay>();
        var coinSelectorMock = Substitute.For<CoinSelector>();
        var coin = new { weight = 21.21, diameter = 5.00 };
        coinSelectorMock.identifyCoin(coin).Returns(Coin.Nickle);
        var vendingMachine = new VendingMachine(
            displayMock,
            coinSelectorMock
        );
        
        vendingMachine.acceptCoin(coin);
        vendingMachine.acceptCoin(coin);

        coinSelectorMock.Received(2).identifyCoin(coin);
        displayMock.ReceivedWithAnyArgs(2);
        displayMock.Received(1).show("0.10");
    }
}