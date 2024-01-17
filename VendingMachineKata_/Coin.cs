namespace VendingMachineKata;

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