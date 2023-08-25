using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadNextRoadTrigger : MonoBehaviour
{
    private bool isWasLoad;
    private void OnTriggerEnter(Collider other)
    {
        if (!isWasLoad && other.GetComponent<RCC_CarControllerV3>())
        {
            InfinityMenuRoad.LoadNextRoad?.Invoke();
            isWasLoad = true;
        }

    }
}
