using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkillsPanel : PanelConfiguration
{
    [SerializeField] private List<BaseSkill> allSkills;
    public override void Show()
    {
        gameObject.SetActive(true);
        for (var i = 0; i < allSkills.Count; i++)
        {
            allSkills[i].InitializeInMenu();
        }
    }

    public override void Hide()
    {
        gameObject.SetActive(false);
    }

    public override void ActivateListeners()
    {
    }
}
