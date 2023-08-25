using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NosManager : MonoBehaviour ,ISkillUse
{
    public delegate void UseNos();

    public UseNos activateNitro;
    [SerializeField] private ParticleSystem _particleSystem;
    [SerializeField] private ActiveSkillStats _skillStats;
    public void Fire()
    {
       Debug.Log("UseNos");
       //PlayerCarForce.ActivateNitro();
       activateNitro();
       _particleSystem.Play();
       _skillStats.ammoCount -= _skillStats.ammoUsePerShot;
    }

    public void SetGunState(ActiveSkillStats activeSkillStats)
    {
        
        _skillStats = activeSkillStats;
    }
}
