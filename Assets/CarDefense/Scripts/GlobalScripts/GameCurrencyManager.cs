using UnityEngine;


public static class GameCurrencyManager
{
    private static int _winWinCoins;
    private static int farmingCoins;

    public static event OnWinCoinsChange OnChangeWinCoins;

    public delegate void OnWinCoinsChange();

    public static event OnFarmingCoinsChange OnChangeFarmingCoins;

    public delegate void OnFarmingCoinsChange();

    public static float WinCoins
    {
        get => _winWinCoins;
        set
        {
            if (_winWinCoins == value) return;
            _winWinCoins = (int) value;
            OnChangeWinCoins?.Invoke();
            SaveWinCoins();
        }
    }

    public static float FarmingCoins
    {
        get => farmingCoins;
        set
        {
            if (farmingCoins == value) return;
            farmingCoins = (int) value;
            OnChangeFarmingCoins?.Invoke();
            SaveFarmingCoins();
        }
    }

    [RuntimeInitializeOnLoadMethod]
    private static void Initialize()
    {
        _winWinCoins = ES3.Load(SaveKeys.WinCoins, 100000);
        farmingCoins = ES3.Load(SaveKeys.FarmingCoins, 1000000);
    }

    private static void SaveWinCoins()
    {
        ES3.Save(SaveKeys.WinCoins, _winWinCoins);
    }
    
    private static void SaveFarmingCoins()
    {
        ES3.Save(SaveKeys.FarmingCoins, farmingCoins);
    }

    public static string PriceConvert(float price)
    {
        string priceKk = price.ToString();

        if (price > 10000 && price < 1000000)
        {
            priceKk = price / 1000 + "K";
        }else if (price > 1000000)
        {
            priceKk = price / 1000000 + "M";
        }
        return priceKk;
    }
    
}