using System;
using System.Collections;
using System.Collections.Generic;
using GameAnalyticsSDK.Setup;
using UnityEngine;

public class InitGameMode : MonoBehaviour
{
    [SerializeField] private List<GameMode> gameModes;

    private void Awake()
    {
        GameModeType gameType = ES3.Load(SaveKeys.GameMode, GameModeType.CareerMode);
        gameModes.Find(e => e.GameModeType == gameType).Initialize();
    }
}
