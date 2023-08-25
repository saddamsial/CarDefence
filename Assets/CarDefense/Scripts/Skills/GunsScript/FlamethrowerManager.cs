using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlamethrowerManager : MonoBehaviour , ISkillUse
{

    [SerializeField] private FlameFire _flameFire;
    [SerializeField] private ActiveSkillStats _skillStats;

    public void Fire()
    {
      Debug.Log("Flame Fire");
      StartCoroutine(FireFlame());
    }

    public void SetGunState(ActiveSkillStats activeSkillStats)
    {
        _skillStats = activeSkillStats;
    }
    
    IEnumerator FireFlame()
    {
        WaitForSeconds attackSpeed = new WaitForSeconds(1/_skillStats.attackSpeed);
        while (_skillStats.ammoUsePerShot >= 0)
        {
            //_fireManager.Fire(_skillStats.bulletDamage);
            _flameFire.Fire(_skillStats.bulletDamage);
            _skillStats.ammoUsePerShot -= 1;
            yield return attackSpeed;
        }
        _skillStats.ammoCount -= _skillStats.ammoUsePerShot;
        _flameFire.ImpactEffect.Stop();
    }

}
