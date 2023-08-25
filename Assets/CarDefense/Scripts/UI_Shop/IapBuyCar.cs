using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "IapBuyCar",menuName = "ShopBuyCar/IapBuyCar",order = 3)]
public class IapBuyCar : ShopBuyCarsType
{
    [FormerlySerializedAs("truckIapItem")] [SerializeField] private IAPItem carIapItem;
 
    public override void BuyCar()
    {
        IAPManager.instance.Buy(carIapItem.Identifier);
    }

    public override void GetReward()
    {
        // carData.Owned = true;
        // GlobalCarsContainer.SaveCurrentTruck(carData);
        // GarageSpawnCar.SpawnCar?.Invoke(carData);
        // GameAnalytics.NewProgressionEvent(GAProgressionStatus.Complete, "GAME_FLOW", "PURCHASE_IAP_CAR_" + carData.CarId);
    }
}
