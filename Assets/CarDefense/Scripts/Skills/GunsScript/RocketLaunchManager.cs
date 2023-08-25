using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketLaunchManager : MonoBehaviour,ISkillUse
{
    [SerializeField] private RocketBullet _rocketBullet;
    [SerializeField] private Transform rocketSpawnPosition; 
    [SerializeField] private Transform rayCastOrigin; 
    [SerializeField] private ActiveSkillStats _skillStats;
    public void Fire()
    {
        Debug.Log("RocketLaunch Fire");
        RocketBullet rocket = Instantiate(_rocketBullet, rocketSpawnPosition);
        rocket.InitializeMove(rayCastOrigin,_skillStats.bulletDamage);
        _skillStats.ammoCount -= _skillStats.ammoUsePerShot;
    }

    public void SetGunState(ActiveSkillStats activeSkillStats)
    {
        _skillStats = activeSkillStats;
        Debug.Log("Set Gun State");
    }
}
