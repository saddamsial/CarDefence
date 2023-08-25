using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class CarSaveStats 
{
    public int carTorqueAdd;
    public int carMassAdd;
    public int carBaseTorque;
    public int carBaseMass;
    public int carBaseHealPoints;
    public ClassType classType;
    public float scoreСoefficient;
    public int carBaseDamage;
    public int carBaseDamageBlock;
    public int reduceSkillPriceCost;
    public float goodIntervalDuration;
    public List<ActiveSkillType> activeSkills;
}
