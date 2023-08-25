using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum GameModeType
{
    CareerMode,
    OnlineMode,
}
public abstract class GameMode : MonoBehaviour
{
    public GameModeType GameModeType;
    public SpawnCars SpawnCars;

    public abstract void Initialize();
    
}
