using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : ActiveSkill
{
    
    public override void UpgradeSkill()
    {
        if (GameCurrencyManager.WinCoins >= UpgradePrice)
        {

            if (!_carSaveStats.activeSkills.Exists(e => e == _skillType))
            {
                _carSaveStats.activeSkills.Add(_skillType);
                CarGunsHolder.ActivateCarGuns.Invoke(_carSaveStats.activeSkills);
                //TODO activate gun
                
            }
            activeSkillStats.upgradeLevel++;
            activeSkillStats.ammoCount += 1;
            activeSkillStats.bulletDamage += 0;
            activeSkillStats.attackSpeed += 0;
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
            upgradeLevel = 0 ,
            priceToUse = 1000 ,// +  ES3.Load(SaveKeys.IapNosPrices ,0)
            ammoCount = 0, // + ES3.Load(SaveKeys.IapNosCharges,0),
            bulletDamage = 0,
            attackSpeed = 0,
            reloadTime = 10,
            ammoUsePerShot = 1,
        });
        UpgradeLevel = activeSkillStats.upgradeLevel;
        UpgradePrice = UpgradeLevel + 1;
    }
    
    public override void UseSkill()
    {
        
    }

    public override void RefreshUiGamePlay()
    {
        
    }
}
