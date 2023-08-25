using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ClassType
{
    None,
    Carry,
    Tank,
}

[CreateAssetMenu(fileName = "CarData", menuName = "Car/CarData", order = 0)]
public class CarData : ScriptableObject
{
    [SerializeField] private int carId;
    [SerializeField] private string pathLocation;
    
    [SerializeField] private CarSaveStats defaultCarStats;
    [SerializeField] private CarSaveStats carSaveStats;
    
    
    public int CarId => carId;

    public string Location => pathLocation;

    public bool Owned
    {
        set { ES3.Save(SaveKeys.CarIsOwned + carId, true); }
        get { return ES3.Load(SaveKeys.CarIsOwned + carId, false); }
    }

    public CarSaveStats SaveStats => carSaveStats;

    public void Initialize()
    {
        carSaveStats = ES3.Load(SaveKeys.CarSaveStats + carId, new CarSaveStats()
        {
   carTorqueAdd = defaultCarStats.carTorqueAdd,
     carMassAdd = defaultCarStats.carMassAdd,
     carBaseTorque = defaultCarStats.carBaseTorque,
    carBaseMass = defaultCarStats.carBaseMass,
     carBaseHealPoints = defaultCarStats.carBaseHealPoints,
     classType = defaultCarStats.classType,
    scoreСoefficient = defaultCarStats.scoreСoefficient,
     carBaseDamage = defaultCarStats.carBaseDamage,
     carBaseDamageBlock = defaultCarStats.carBaseDamageBlock,
     reduceSkillPriceCost = defaultCarStats.reduceSkillPriceCost,
     goodIntervalDuration = defaultCarStats.goodIntervalDuration,
     activeSkills = new List<ActiveSkillType>(),
        });
        
    }

    public void CarSaveStats()
    {
        ES3.Save(SaveKeys.CarSaveStats + carId, carSaveStats);
    }
    
}