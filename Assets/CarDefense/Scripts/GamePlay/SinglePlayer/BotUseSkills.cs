using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotUseSkills : MonoBehaviour
{
    [SerializeField] private List<ActiveSkillType> botSkills = new List<ActiveSkillType>();
    
    public void Initialize(CarComponents botComponents)
    {
        botSkills = GlobalCareerContainer.currentLevel.BotCarStats.activeSkills;
        //Activate guns on bot car 
        botComponents.carGunsHolder.InitializeGunsInMenu(botSkills);
    }
}
