using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CareerMode : GameMode
{
    public override void Initialize()
    {
        SpawnCars.CareerSpawnCar();
    }
}
