using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BuyType
{
    WinCoins,
    FarmingCoins,
    Ads,
    Iap
}
public  abstract class ShopBuyCarsType : ScriptableObject
{
    [SerializeField] private BuyType buyType;
    [SerializeField] private float price;
    [SerializeField] private CarData carData;
    [SerializeField] private int shopOrder;
    [SerializeField] private Sprite truckSprite;
    [SerializeField] private float oldPrice;

    public BuyType Type => buyType;

    public float Price => price;

    public CarData CarBuy => carData;

    public int ShopOrder => shopOrder;

    public Sprite TruckSprite => truckSprite;

    public float OldPrice => oldPrice;

    public abstract void BuyCar();


    public abstract void GetReward();

}
