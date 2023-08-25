﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T :MonoBehaviour
{
    [SerializeField]
    private bool dontDestroy = false;

    private static T _instance;

    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<T>();
                if (_instance == null)
                {
                    GameObject singleton = new GameObject(typeof(T).Name);
                    _instance = singleton.AddComponent<T>();
                }
            }
            return _instance;
        }
    }

    protected void Awake()
    {
        if (_instance == null)
        {
            _instance = this as T;
            if (dontDestroy)
            {
                transform.parent = null;
                DontDestroyOnLoad(this.gameObject);
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }


}
/*
  if(GM.NoAds)
        {
            SpinAdReward();
              Debug.Log("Spin withoud ads!");
        }
        else if (AdsEnabled)
        {
            Debug.Log("Spin with ads :(((");
            adScript.spinIsShowing = true;
            adScript.ShowRewardVideo("Spin_REWARD");
            adScript.wasRequested = true;
        }
        else
        {
            if (debugMNG.debugMode && debugMNG.adsActive)
                SpinAdReward();
            else if (!debugMNG.debugMode || !debugMNG.adsActive)
                return;
        }
    }
*/
