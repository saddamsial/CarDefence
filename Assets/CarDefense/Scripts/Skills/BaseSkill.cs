using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public enum ActiveSkillType
{
    MachineGun,
    Flamethrower,
    RocketLauncher,
    IceTrap,
    ElectricStun,
    PushBack,
    Shield,
    NOS,
    RemoveStuns,
    Heal,
    AntiSkid,
    
    
}

public enum PassiveSkillType
{
    DamageAttack,
    HorsePower,
    Acceleration,
    SkillPrices,
    ScoreCoefficient,
    HealPoints,
    CarMass,
    DamageBlock,
    PushResistance,
    GoodIntervalDuration,
    
}
public abstract class BaseSkill : MonoBehaviour
{
    
    [SerializeField] protected int MaxUpgradeLevel;
    [SerializeField] protected Sprite Icon;
    [SerializeField] protected Button skillButton;
    [SerializeField] protected TextMeshProUGUI infoText;
    [SerializeField] protected TextMeshProUGUI ammoCountText;
    protected int UpgradePrice;
    protected int UpgradeLevel;
    
    



    public abstract void InitializeInMenu();
    public abstract void UpgradeSkill();
    
    public abstract void RefreshUi();
    
    public abstract void SaveUpgrade();
}
