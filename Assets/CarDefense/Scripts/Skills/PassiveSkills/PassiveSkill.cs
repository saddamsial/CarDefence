using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PassiveSkill : BaseSkill
{
    [SerializeField] private PassiveSkillType _passiveSkillType;
    [SerializeField] private CarSaveStats _carSaveStats;
   


    public override void InitializeInMenu()
    {
        _carSaveStats = GlobalCarsContainer.currentCar.SaveStats;
        UpgradeLevel  = ES3.Load(_passiveSkillType.ToString() + GlobalCarsContainer.currentCar.CarId, 0);
        UpgradePrice = UpgradeLevel + 1;
      //  ammoCountText.gameObject.SetActive(false);
        RefreshUi();
    }

    public override void UpgradeSkill()
    {
        if (GameCurrencyManager.WinCoins >= UpgradePrice)
        {
            switch (_passiveSkillType)
            {
                case PassiveSkillType.DamageAttack :
                    _carSaveStats.carBaseDamage += 10;
                    break;
                case PassiveSkillType.HorsePower :
                    _carSaveStats.carBaseTorque += 50;
                    break;
                case PassiveSkillType.Acceleration :
                    _carSaveStats.carTorqueAdd += 10;
                    break;
                case PassiveSkillType.SkillPrices :
                    _carSaveStats.reduceSkillPriceCost += 10;
                    break;
                case PassiveSkillType.ScoreCoefficient :
                    _carSaveStats.scoreСoefficient += 0.2f;
                    break;
                case PassiveSkillType.HealPoints :
                    _carSaveStats.carBaseHealPoints += 100;
                    break;
                case PassiveSkillType.CarMass :
                    _carSaveStats.carBaseMass += 100;
                    break;
                case PassiveSkillType.DamageBlock :
                    _carSaveStats.carBaseDamageBlock += 5;
                    break;
                case PassiveSkillType.PushResistance :
                    _carSaveStats.carMassAdd += 10;
                    break;
                case PassiveSkillType.GoodIntervalDuration :
                    _carSaveStats.goodIntervalDuration += 1;
                    break;
            }

            GameCurrencyManager.WinCoins -= UpgradePrice;
            SaveUpgrade();
          
        }
        else
        {
            //TODO show Panel NotEnoughMoney
        }
    }


    public override void RefreshUi()
    {
        skillButton.onClick.RemoveAllListeners();
        
        if (UpgradeLevel >= MaxUpgradeLevel)
        {
            infoText.text = "Max";
            //TODO setUI for Max Upgrade
        }
        else
        {
            infoText.text = $"{UpgradeLevel}/{MaxUpgradeLevel}";
            skillButton.onClick.AddListener(UpgradeSkill);
        }
    }

    public override void SaveUpgrade()
    {
        GlobalCarsContainer.currentCar.CarSaveStats();
        UpgradeLevel++;
        UpgradePrice = UpgradeLevel + 1;
        ES3.Save(_passiveSkillType.ToString() + GlobalCarsContainer.currentCar.CarId, UpgradeLevel);
        RefreshUi();
    }
    
}
