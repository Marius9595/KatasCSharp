using FsCheck;
using NSubstitute;
using NSubstitute.ReceivedExtensions;

namespace VendingMachineKata;

public class DigitalDisplay
{
    public virtual void show(string message)
    {
        throw new NotImplementedException();
    }
}

public enum CoinType
{
    Nickle = 5,
    Dime = 10,
    Quarter = 25,
    Penny = 1
}

public class CoinSelector
{
    public virtual CoinType identifyCoin(object coin)
    {
        throw new NotImplementedException();
    }
}

public class VendingMachineShould
{
    private readonly string _insertCoinMessage = "INSERT COIN (0.00$)";
    [Fact]
    public void display_INSERT_COIN_when_no_coins_have_been_inserted()
    {
        var displayMock = Substitute.For<DigitalDisplay>();
        var coinSelectorMock = Substitute.For<CoinSelector>(); 
        
        VendingMachine.startUp(
            displayMock,
            coinSelectorMock
        );
        
        displayMock.Received().show(_insertCoinMessage);
    }
    
    [Theory]
    [InlineData(5.00, 21.21, CoinType.Nickle, "0.05")]
    [InlineData(2.26, 17.91, CoinType.Dime, "0.10")]
    [InlineData(5.67, 24.26, CoinType.Quarter, "0.25")]
    public void display_the_value_of_a_valid_coin_inserted_when_it_is_the_first_one(
        decimal weight,
        decimal diameter,
        CoinType coinTypeIdentifiedExpected,
        string messageToDisplayExpected
    )
    {
        var displayMock = Substitute.For<DigitalDisplay>();
        var coinSelectorMock = Substitute.For<CoinSelector>();
        var coin = new { weight = weight, diameter = diameter };
        coinSelectorMock.identifyCoin(coin).Returns(coinTypeIdentifiedExpected);
        var vendingMachine = VendingMachine.startUp(
            displayMock,
            coinSelectorMock
        );
        
        vendingMachine.acceptCoin(coin);

        coinSelectorMock.Received().identifyCoin(coin);
        displayMock.Received(1).show(_insertCoinMessage);
        displayMock.Received(1).show(messageToDisplayExpected);
    }
    
    [Fact]
    public void update_the_display_when_consecutive_valid_coins_are_inserted_showing_the_total_amount_of_money_after_each_coin_inserted()
    {
        var displayMock = Substitute.For<DigitalDisplay>();
        var coinSelectorMock = Substitute.For<CoinSelector>();
        var coin = new { weight = 21.21, diameter = 5.00 };
        coinSelectorMock.identifyCoin(coin).Returns(CoinType.Nickle);
        var vendingMachine = VendingMachine.startUp(
            displayMock,
            coinSelectorMock
        );
        
        vendingMachine.acceptCoin(coin);
        vendingMachine.acceptCoin(coin);

        coinSelectorMock.Received(2).identifyCoin(coin);
        displayMock.ReceivedWithAnyArgs(2);
        displayMock.Received(1).show(_insertCoinMessage);
        displayMock.Received(1).show("0.10");
    }
    
    [Fact]
    public void not_update_display_when_an_invalid_coin_is_inserted()
    {
        var displayMock = Substitute.For<DigitalDisplay>();
        var coinSelectorMock = Substitute.For<CoinSelector>();
        var invalidCoin = new { weight = 19.05, diameter = 2.50 };
        coinSelectorMock.identifyCoin(invalidCoin).Returns((CoinType.Penny));
        var vendingMachine = VendingMachine.startUp(
            displayMock,
            coinSelectorMock
        );
        
        vendingMachine.acceptCoin(invalidCoin);

        coinSelectorMock.Received(1).identifyCoin(invalidCoin);
        displayMock.Received(1).show(_insertCoinMessage);
    }

    [Fact]
    public void display_the_price_of_an_product_select_while_there_is_not_enough_money()
    {
    }
}