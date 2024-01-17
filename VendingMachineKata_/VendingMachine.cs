using System.Net.Sockets;
using Xunit.Sdk;

namespace VendingMachineKata;

class VendingMachine
{
    private readonly DigitalDisplay _display;
    private readonly CoinSelector _coinSelector;
    private Money _amountOfMoney = new Money(0);

    public VendingMachine(DigitalDisplay display, CoinSelector coinSelector)
    {
        _display = display;
        _coinSelector = coinSelector;
    }
    
    public static VendingMachine startUp(DigitalDisplay display, CoinSelector coinSelector)
    {
        display.show("INSERT COIN");
        return new VendingMachine(display, coinSelector);
    }

    public void acceptCoin(object coinInserted)
    {
        var coinIdentified = _coinSelector.identifyCoin(coinInserted);
        if (coinIdentified == CoinType.Penny)
        {
            return;
        }
        
        var coin = Coin.create(coinIdentified);
        _amountOfMoney = _amountOfMoney.sum(coin.value);
        _display.show(_amountOfMoney.ToString());
    }
}

public class Coin
{
    private readonly Money _value;
    
    public static Coin create(CoinType coinType) 
    {
        switch (coinType)
        {
            case CoinType.Dime:
                return new Coin(new Money(0.10));
            case CoinType.Quarter:
                return new Coin(new Money(0.25));
            case CoinType.Nickle:
                return new Coin(new Money(0.05));
            case CoinType.Penny:
                return new Coin(new Money(0.01));
            default:
                throw new Exception("not implemented");
        }
    }
    
    private Coin(Money value)
    {
        _value = value;
    }

    public Money value => _value;
}


public class Money
{
    private readonly double _value;

    public Money(double value)
    {
        _value = value;
    }
    
    public Money sum(Money money)
    {
        return new Money(_value + money._value);
    }

    public override string ToString()
    {
        return _value.ToString("0.00").Replace(",",".");
    }
}