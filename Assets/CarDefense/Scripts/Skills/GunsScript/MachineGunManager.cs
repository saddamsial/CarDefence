using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGunManager : MonoBehaviour , ISkillUse
{
    [SerializeField] private FPSFireManager _fireManager;
    [SerializeField] private ActiveSkillStats _skillStats;
    
    public void Fire()
    {
        Debug.Log("MachineGun Fire");
        StartCoroutine(FireMachineGun());

    }
    
    public void SetGunState(ActiveSkillStats activeSkillStats)
    {
        _skillStats = activeSkillStats;
        Debug.Log("Set Gun State");
    }

    IEnumerator FireMachineGun()
    {
        WaitForSeconds attackSpeed = new WaitForSeconds(1/_skillStats.attackSpeed);
        while (_skillStats.ammoUsePerShot >= 0)
        {
            _fireManager.Fire(_skillStats.bulletDamage);
            _skillStats.ammoUsePerShot -= 1;
            yield return attackSpeed;
        }

        _skillStats.ammoCount -= _skillStats.ammoUsePerShot;
    }
}