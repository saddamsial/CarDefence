using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnlineMode : GameMode
{
    public override void Initialize()
    {
        SpawnCars.OnlineSpawnCar();
    }
}
