using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyWallet : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI winCoinsText;
    [SerializeField] private TextMeshProUGUI farmingCoinsText;


    private void Awake()
    {
        GameCurrencyManager.OnChangeWinCoins += SetWinCoinsText;
        SetWinCoinsText();

        GameCurrencyManager.OnChangeFarmingCoins += SetFarmingText;
        SetFarmingText();
        
    }

    private void SetWinCoinsText()
    {
        winCoinsText.text = GameCurrencyManager.PriceConvert(GameCurrencyManager.WinCoins) + " <sprite index=[2]>";
    }

    private void SetFarmingText()
    {
        farmingCoinsText.text = GameCurrencyManager.PriceConvert(GameCurrencyManager.FarmingCoins) + " <sprite index=[0]>";
    }
    
}
