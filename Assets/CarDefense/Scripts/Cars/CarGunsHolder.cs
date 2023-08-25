using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CarGunsHolder : MonoBehaviour
{
   public static UnityEvent<List<ActiveSkillType>> ActivateCarGuns = new UnityEvent<List<ActiveSkillType>>();
   [SerializeField] private MachineGunManager machineGun;
   [SerializeField] private RocketLaunchManager rocketLauncher;
   [SerializeField] private FlamethrowerManager flamethrower;
   [SerializeField] private NosManager nosManager;
 
   
   private void Start()
   {
      ActivateCarGuns.AddListener(InitializeGunsInMenu);
   }

   // public void ActivateMachineGun()
   // {
   //    machineGun.gameObject.SetActive(true);
   //    machineGun.SetGunState();
   //    
   // }
   //
   // public void ActivateRocketLauncher()
   // {
   //    rocketLauncher.SetActive(true);
   // }
   //
   // public void ActivateFlamethrower()
   // {
   //    flamethrower.SetActive(true);
   // }
   //
   // public void ActivateNosBanks()
   // {
   //    nosBanks.SetActive(true);
   // }
   public void InitializeGunsInMenu(List<ActiveSkillType> saveStatsActiveSkills)
   {
      for (var i = 0; i < saveStatsActiveSkills.Count; i++)
      {
         switch (saveStatsActiveSkills[i])
         {
            case ActiveSkillType.MachineGun :
             machineGun.gameObject.SetActive(true);
               break;
            case ActiveSkillType.RocketLauncher:
               rocketLauncher.gameObject.SetActive(true);
               break;
            case ActiveSkillType.Flamethrower:
               flamethrower.gameObject.SetActive(true);
               break;
            case ActiveSkillType.NOS:
               nosManager.gameObject.SetActive(true);
               break;
         }
      }
   }

   public Action InitializeGunsInGamePlay(ActiveSkillType activeSkillType,ActiveSkillStats activeSkillStats)
   {
      switch (activeSkillType)
      {
         case ActiveSkillType.MachineGun :
            machineGun.gameObject.SetActive(true);
            machineGun.SetGunState(activeSkillStats);
            return ()=> machineGun.Fire();
         case ActiveSkillType.RocketLauncher:
            rocketLauncher.gameObject.SetActive(true);
            rocketLauncher.SetGunState(activeSkillStats);
            return ()=> rocketLauncher.Fire();
         case ActiveSkillType.Flamethrower:
            flamethrower.gameObject.SetActive(true);
            flamethrower.SetGunState(activeSkillStats);
            return ()=> flamethrower.Fire();
         case ActiveSkillType.NOS:
            nosManager.gameObject.SetActive(true);
            return ()=> nosManager.Fire();
      }
      return null;
   }

   public void SetNosFunction(NosManager.UseNos useNos)
   {
      
      nosManager.activateNitro = useNos;
   }
}
