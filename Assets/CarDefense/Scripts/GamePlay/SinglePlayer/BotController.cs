using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;

public class BotController : MonoBehaviour
{
    [SerializeField] private RCC_CarControllerV3 botControllerV3;
    
    [SerializeField] private Rigidbody botRigid;

    [SerializeField] private BotUseSkills _botUseSkills;

    [SerializeField] private PlayersHealManager _playersHealManager;



    private bool isInitializeMove;
    //Bot speed
    private float maxSpeed = 50f;
    
    //Bot Mass
    private float botMinRigidMass;
    private int massAddCount;
    
    //BotPower
    private float botMinEngineTorque;
    private bool botIncreasePower = false;
    private int torqueAddCount;
    
    
    
    //Bot NOS Controller
    private bool isNitro;
    private int nitroTrigger;
    private int nitroReady;
    private int nitroTimes = 3;

//Bot Change stats
    private int waitMinSeconds;
    private int waitMaxSeconds;

    private CarComponents _carComponents;
    
    
    public void InitializeBotStats(RCC_CarControllerV3 botController)
    {
        botControllerV3 = botController;
        _carComponents = botController.GetComponent<CarComponents>();
        _botUseSkills.Initialize(_carComponents);
        _carComponents.CarHealBar.Initialize(GlobalCareerContainer.currentLevel.BotCarStats.carBaseHealPoints);
        _carComponents.CarHealBar.SetCarHealBar(_playersHealManager.enemyHealBar);
        botRigid = _carComponents.rigid;
        
        nitroReady = Random.Range(2, 6);        
      
     


        botMinRigidMass = GlobalCareerContainer.currentLevel.BotCarStats.carBaseMass;
        botRigid.mass = botMinRigidMass;
        
        botMinEngineTorque = GlobalCareerContainer.currentLevel.BotCarStats.carBaseTorque;
        botControllerV3.maxEngineTorque = botMinEngineTorque;
        
        massAddCount = GlobalCareerContainer.currentLevel.BotCarStats.carMassAdd;
        torqueAddCount = GlobalCareerContainer.currentLevel.BotCarStats.carTorqueAdd;
        maxSpeed = GlobalCareerContainer.currentLevel.MaxSpeed;
        
        if (_carComponents.anim)
        {
            _carComponents.anim.SetTrigger("StartAnim");
        }
        
    }
    
    public void InitializeMove()
    {
        isInitializeMove = true;
        botControllerV3.PreviewSmokeParticle(true);
        StartCoroutine(AddForce());
    }


    private void Update()
    {
        if (isInitializeMove)
        {
            if (botIncreasePower)
            {
                botControllerV3.maxEngineTorque += torqueAddCount;
                botRigid.mass += massAddCount;
            }else if (isNitro)
            {
                botControllerV3.maxEngineTorque += 500;
                botRigid.mass += 200;
                botControllerV3.boostInput = 1f;
            }
            else if (!botIncreasePower)
            {
                botRigid.mass = botMinRigidMass;
                botControllerV3.maxEngineTorque = botMinEngineTorque;
            }
            botRigid.velocity = Vector3.ClampMagnitude(botRigid.velocity, maxSpeed);
        }
       

        
    }

    IEnumerator AddForce()
    { 
        
        BotSetData();
        
        while (true)
        {
            nitroTrigger++;
            if (nitroTrigger == nitroReady)
            {
                BotStartNitro();
            }

            SetWaitTimes();
            yield return new WaitForSeconds(waitMinSeconds);
            botIncreasePower = true;
            yield return new WaitForSeconds(waitMaxSeconds);
            botIncreasePower = false;
        }
       
    }

    private void BotStartNitro()
    {
        isNitro = true;
        maxSpeed = 100f;
        var localVel = botControllerV3.transform.InverseTransformDirection(botRigid.velocity);
 
        if (localVel.z > 0)
        {
            Debug.Log(" Bot Move Forward");
        }
        else
        {
            botRigid.isKinematic = true;
            DOVirtual.DelayedCall(0.2f, () =>
            {
                botRigid.isKinematic = false;
            });
        }
        
        DOVirtual.DelayedCall(2f, () =>
        {
            isNitro = false;
            botControllerV3.boostInput = 0;
            nitroTimes--;
            if (nitroTimes > 0)
            {
                nitroTrigger = 0;
                nitroReady = Random.Range(1, 3);    
            }
            maxSpeed = 5f;
        });
    }
    
    

    private void BotSetData()
    {
        botControllerV3.PreviewSmokeParticle(true);
        
    }

    private void SetWaitTimes()
    {
        waitMinSeconds = Random.Range(1, 3);
        waitMaxSeconds = Random.Range(2, 6);
    }

   
}
