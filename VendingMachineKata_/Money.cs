    namespace VendingMachineKata;

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