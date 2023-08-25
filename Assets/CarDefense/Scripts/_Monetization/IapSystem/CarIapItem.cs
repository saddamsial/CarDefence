using System.Collections;
using System.Collections.Generic;
using GameAnalyticsSDK;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "CarIapItem", menuName = "IAP/CarIapItem", order = 0)]
public class CarIapItem : IAPItem
{
   [SerializeField] private CarData carData;

   public override void GetReward()
   {
      carData.Owned = true;
      GlobalCarsContainer.SaveCurrentCar(carData);
      GarageSpawnCar.SpawnCar?.Invoke(carData);
      GameAnalytics.NewProgressionEvent(GAProgressionStatus.Complete, "GAME_FLOW", "PURCHASE_IAP_CAR_" + carData.CarId);

   }
}
