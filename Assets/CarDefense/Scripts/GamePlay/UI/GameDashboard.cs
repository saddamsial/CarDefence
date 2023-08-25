using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDashboard : MonoBehaviour
{
    [SerializeField] private Transform needle;
    public bool isGasDown;
    private float needleRotation;

    private bool isIncrease;
    // Start is called before the first frame update
    public void Initialize()
    {
        isIncrease = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isIncrease)
        {
            
            if (isGasDown)
            {
                needleRotation -= 1.5f;//TODO to make upgrade for needleRotation moving,tipa sa se miste mai repede 
                needleRotation = Mathf.Clamp(  needleRotation,-180,0);
                needle.eulerAngles = new Vector3(needle.eulerAngles.x ,needle.eulerAngles.y, needleRotation);
            }
            else
            {
                needleRotation += 1;
                needleRotation = Mathf.Clamp(  needleRotation,-180,0);
                needle.eulerAngles = new Vector3(needle.eulerAngles.x ,needle.eulerAngles.y, needleRotation);
            }
            
        }
    }

    public void ChangeGas()
    {
        isGasDown = true;
    }

    public void ChangeGasUp()
    {
        isGasDown = false;
    }
}
