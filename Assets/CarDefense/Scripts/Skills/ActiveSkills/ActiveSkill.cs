

using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;


[Serializable]
public struct ActiveSkillStats
{
    public int upgradeLevel;
    public float priceToUse;
    public int ammoCount;
    public int bulletDamage;
    public float attackSpeed; // bullet per seconds
    public float reloadTime;
    public int ammoUsePerShot;
}

public  class ActiveSkill : BaseSkill
{
    [SerializeField] protected ActiveSkillType _skillType;
   
    [SerializeField] protected Image reloadImage;

    [SerializeField] protected SkillsManagerGamePlay _skillsManagerGamePlay;
    
    [SerializeField] protected CarSaveStats _carSaveStats;
    [SerializeField] protected ActiveSkillStats activeSkillStats;
    
    private bool isReload;

    public ActiveSkillType SkillType => _skillType;


    public override void InitializeInMenu()
    {
        _carSaveStats = GlobalCarsContainer.currentCar.SaveStats;
        LoadSkillStats();
        RefreshUi();
    }

    public override void UpgradeSkill()
    {
        
    }

    public override void RefreshUi()
    {
        skillButton.onClick.RemoveAllListeners();
        ammoCountText.text = activeSkillStats.ammoCount + " Ammo";
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
    }


    public virtual void LoadSkillStats()
    {
        
    }
    
    public virtual ActiveSkillStats InitializeGamePlay()
    {
        LoadSkillStats();
        gameObject.SetActive(true);
        infoText.text = activeSkillStats.priceToUse + "<sprite index=1>";
        ammoCountText.text = activeSkillStats.ammoCount + " Ammo";
        skillButton.onClick.AddListener(UseSkill);
        return activeSkillStats;
    }

    public virtual void UseSkill()
    {
        Debug.Log("Use Skill fillAmount");
        reloadImage.fillAmount = 1;
        isReload = true;
        skillButton.interactable = false;
        _skillsManagerGamePlay.UseScoreForSkill(activeSkillStats.priceToUse);
        activeSkillStats.ammoCount -= activeSkillStats.ammoUsePerShot;
        ammoCountText.text = activeSkillStats.ammoCount + " Ammo";
        reloadImage.DOFillAmount(0, activeSkillStats.reloadTime).OnComplete(() =>
        {
            isReload = false;
        });
    }

    public virtual  void RefreshUiGamePlay()
    {
        
    }

    //Chek if it's enough ammo and price for use skill
    public void CheckSkillState(float scoreAmount)
    {
        if (!isReload)
        {
            skillButton.interactable = (scoreAmount >= activeSkillStats.priceToUse && activeSkillStats.ammoCount > 0);
        }
       
    }

    public void SetActionForSkillButton(Action gunFireAction,SkillsManagerGamePlay skillsManagerGamePlay)
    {
        _skillsManagerGamePlay = skillsManagerGamePlay;
        skillButton.onClick.AddListener(()=> gunFireAction());
    }


   
}
