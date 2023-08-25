using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using DG.Tweening;
using UnityEngine;

public class PlayerCarForce : MonoBehaviour
{
    [SerializeField] private RCC_CarControllerV3 playerControllerV3;
   
    [SerializeField] private Rigidbody playerRigid;
   
    [SerializeField] private GameDashboard gameDashboard;

    [SerializeField] private CinemachineVirtualCamera cinemaCamera;
    public NoiseSettings nitroNoise ;
   
    
    public bool isIncrease;
    public bool isInitialize;
    
    
    private bool isNitro;

    private float maxSpeed = 50f;
    private int torqueAddCount;
    private int massAddCount;
    
    private float playerMinEngineTorque;
    private float playerMinRigidMass;

    private CarComponents _carComponents;
 
  
    


    public void InitializeStats(CarComponents playerCarComponents)
    {
        _carComponents = playerCarComponents;
        _carComponents.carData.Initialize();

        playerControllerV3 = _carComponents.CarControllerV3;
     
        playerRigid = _carComponents.rigid;
        gameDashboard.Initialize();
      
        
        //Apply upgrade
            //Set Mass
        playerMinRigidMass = _carComponents.carData.SaveStats.carBaseMass;
        playerRigid.mass = playerMinRigidMass;
        massAddCount = _carComponents.carData.SaveStats.carMassAdd;
        
            //Set Torque
        playerMinEngineTorque = _carComponents.carData.SaveStats.carBaseTorque;
        playerControllerV3.maxEngineTorque = playerMinEngineTorque;
        torqueAddCount = _carComponents.carData.SaveStats.carTorqueAdd;


        if (_carComponents.anim)
        {
            _carComponents.anim.SetTrigger("StartAnim");
        }
        
        //Subscribe methode for NOS
        _carComponents.carGunsHolder.SetNosFunction(ActivateNitro);

    }

    public void InitializeMove()
    {
        isInitialize = true;
        //Auto throttle input
        playerControllerV3.PreviewSmokeParticle(true);
    }

    

    private void Update()
    {
        if (isInitialize)
        {
            if (isIncrease)
            {
                playerControllerV3.maxEngineTorque += torqueAddCount;
                playerRigid.mass += massAddCount;
            }
            else if (isNitro)
            {
                playerControllerV3.maxEngineTorque += (500+torqueAddCount);
                playerRigid.mass += (200 + massAddCount);
                playerControllerV3.boostInput += 1f;
            }
            else
            {
            
                playerControllerV3.maxEngineTorque = playerMinEngineTorque ;
                playerRigid.mass = playerMinRigidMass;

            }

            playerRigid.velocity = Vector3.ClampMagnitude(playerRigid.velocity, maxSpeed);

        }
       
     //   var localVel = playerControllerV3.transform.InverseTransformDirection(playerRigid.velocity);

        
    }

    public void ActivateNitro()
    {
        isNitro = true;
        maxSpeed = 100;
        NoiseSettings currentNoise =
            cinemaCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_NoiseProfile;
        cinemaCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_NoiseProfile = nitroNoise;
        var localVel = playerControllerV3.transform.InverseTransformDirection(playerRigid.velocity);

        if (localVel.z >= 0)
        {
           Debug.Log("Move Forward");
        }
        else
        {
            playerRigid.isKinematic = true;
            DOVirtual.DelayedCall(0.2f, () =>
            {
                playerRigid.isKinematic = false;
            });
        }

       
        DOVirtual.DelayedCall(2f, () =>
        {
            isNitro = false;   
            playerControllerV3.boostInput = 0;
            cinemaCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_NoiseProfile = currentNoise;
            maxSpeed = 50;
        });                            
    }
    
   

   
}
