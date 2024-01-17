namespace VendingMachineKata;

class VendingMachine
{
    private readonly DigitalDisplay _display;
    private readonly CoinSelector _coinSelector;
    private double _amountOfMoney = 0;

    public VendingMachine(DigitalDisplay display, CoinSelector coinSelector)
    {
        _display = display;
        _coinSelector = coinSelector;
    }

    public void acceptCoin(object coin)
    {
        var coinIdentified = _coinSelector.identifyCoin(coin);

        if (coinIdentified == Coin.Dime)
        {
            _amountOfMoney += 0.10;
        }else if(Coin.Quarter == coinIdentified)
        {
            _amountOfMoney += 0.25;
        }else if(Coin.Nickle == coinIdentified)
        {
            _amountOfMoney += 0.05;
        }
        
        _display.show(_amountOfMoney.ToString("0.00").Replace(",","."));
    }
}

