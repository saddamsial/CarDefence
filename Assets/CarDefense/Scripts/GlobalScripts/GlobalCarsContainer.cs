using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class GlobalCarsContainer
{

    public static List<CarData> allCarsList = new List<CarData>();
    public static CarData currentCar;

    [RuntimeInitializeOnLoadMethod]
     static void Initialize()
    {
        Debug.Log("Initialize");
         allCarsList = Resources.LoadAll<CarData>(PathLocation.CarDataLocation).ToList();
        if (ES3.Load(SaveKeys.OwnedCars, 0) == 0)
        {
            allCarsList.Find(e => e.CarId == 0).Owned = true;
            ES3.Save(SaveKeys.OwnedCars,1);
        }
         currentCar = allCarsList.Find(e => e.CarId == ES3.Load(SaveKeys.CurrentCar, 0));

        
    }

     public static void SaveCurrentCar(CarData carData)
     {
         currentCar = carData;
         ES3.Save(SaveKeys.CurrentCar, carData.CarId);
     }
}
