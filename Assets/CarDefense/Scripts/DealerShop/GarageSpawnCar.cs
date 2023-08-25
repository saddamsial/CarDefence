using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class GarageSpawnCar : MonoBehaviour
{
    public static Action<CarData> SpawnCar;
    [SerializeField] private GameObject car;
    //private TruckControlers truckController;
    
    


    private void Awake()
    {
        SpawnCar += SpawnCurrentTruck;
    }
    private void SpawnCurrentTruck(CarData carData)
    {
        if (car != null)
        {
            Destroy(car);
        }
        car = Instantiate(Resources.Load<GameObject>(carData.Location), transform);
        car.GetComponent<RCC_PhotonNetwork>().enabled = false;
        if (carData.Owned)
        {
            GlobalCarsContainer.SaveCurrentCar(carData);
           
        }
        car.GetComponent<CarComponents>().carData.Initialize();
      
    }

    private void OnDestroy()
    {
        SpawnCar -= SpawnCurrentTruck;
 
    }
}