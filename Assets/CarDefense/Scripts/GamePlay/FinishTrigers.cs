using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishTrigers : MonoBehaviour
{
    [SerializeField] private FinishPanel finishPanel;
    [SerializeField] private ScoreInfo scoreInfo;
    public bool isPlayerFinish;

    

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<RCC_CarControllerV3>())
        {
            FinishRace();
        }
       
    }

    public void FinishRace()
    {
        scoreInfo.givePoint = false;
            
        Time.timeScale = 0f;
        finishPanel.Initialize(isPlayerFinish,scoreInfo.scoreAmount);
    }
}