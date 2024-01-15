namespace VendingMachineKata;

class VendingMachine
{
    private readonly DigitalDisplay _display;
    private readonly CoinSelector _coinSelector;

    public VendingMachine(DigitalDisplay display, CoinSelector coinSelector)
    {
        _display = display;
        _coinSelector = coinSelector;
    }

    public void acceptCoin(object coin)
    {
        var coinIdentified = _coinSelector.identifyCoin(coin);
        _display.show("0.05");
    }
}

