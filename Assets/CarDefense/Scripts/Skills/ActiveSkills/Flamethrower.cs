using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flamethrower : ActiveSkill
{
    public override void UpgradeSkill()
    {
        if (GameCurrencyManager.WinCoins >= UpgradePrice)
        {

            if (!_carSaveStats.activeSkills.Exists(e => e == _skillType))
            {
                _carSaveStats.activeSkills.Add(_skillType);
                CarGunsHolder.ActivateCarGuns.Invoke(_carSaveStats.activeSkills);
            }
            
            activeSkillStats.upgradeLevel++;
            activeSkillStats.ammoCount += 50;
            activeSkillStats.bulletDamage += 1;
            activeSkillStats.attackSpeed += 0.5f;
            activeSkillStats.reloadTime -= 0.5f;
                
            UpgradeLevel = activeSkillStats.upgradeLevel;
            UpgradePrice = UpgradeLevel + 1;
            
            GameCurrencyManager.WinCoins -= UpgradePrice;
            SaveUpgrade();
        }
        else
        {
            //TODO show Panel NotEnoughMoney
        }
    }

    public override void SaveUpgrade()
    {
        base.SaveUpgrade();
        ES3.Save(_skillType.ToString() + GlobalCarsContainer.currentCar.CarId, activeSkillStats);
        RefreshUi();
    }

    public override void LoadSkillStats()
    {
        activeSkillStats = ES3.Load(_skillType.ToString() + GlobalCarsContainer.currentCar.CarId, new ActiveSkillStats()
        {
            upgradeLevel = 0,
            priceToUse = 1000,
            ammoCount = 0,
            bulletDamage = 5,
            attackSpeed = 5f,
            reloadTime = 15,
            ammoUsePerShot = 50,
        });
        UpgradeLevel  =activeSkillStats.upgradeLevel;
        UpgradePrice = UpgradeLevel + 1;
    }
    

    public override void UseSkill()
    {
        base.UseSkill();
    }

    public override void RefreshUiGamePlay()
    {
        
    }
}
