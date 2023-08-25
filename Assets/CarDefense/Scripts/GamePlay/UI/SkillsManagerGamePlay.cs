using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;

public class SkillsManagerGamePlay : MonoBehaviour
{
   [SerializeField] private ScrollRect scrollAttackSkills;
   [SerializeField] private ScrollRect scrollDefSkills;
   [SerializeField] private List<ActiveSkill> allGamePlaySkills;
   [SerializeField] private ScoreInfo _scoreInfo;
   
   

   private CarComponents _carComponents;

   private bool isActiveAttack;
   private bool isActiveDef;


   public void Initialize(CarComponents carComponents)
   {
      _carComponents = carComponents;
      List<ActiveSkillType> activeSkillTypes = _carComponents.carData.SaveStats.activeSkills;
      
      for (var i = 0; i < activeSkillTypes.Count; i++)
      {
         ActiveSkill activeSkill = allGamePlaySkills.Find(e => e.SkillType == activeSkillTypes[i]);
        
         activeSkill.SetActionForSkillButton( _carComponents.carGunsHolder.InitializeGunsInGamePlay(activeSkillTypes[i], 
            activeSkill.InitializeGamePlay()),this);
      }
   }

   
   
   
   
   //it's called for AttackSkills button in GamePlay
   public void ActiveAttackContent()
   {
      isActiveAttack = !isActiveAttack;
      
      scrollAttackSkills.gameObject.SetActive(isActiveAttack);
      scrollDefSkills.gameObject.SetActive(false);
      isActiveDef = false;
   }
   
   //it's called for DefSkills button in GamePlay
   public void ActiveDefContent()
   {
      isActiveDef = !isActiveDef;
      scrollDefSkills.gameObject.SetActive(isActiveDef);
      scrollAttackSkills.gameObject.SetActive(false);
      isActiveAttack = false;

   }

   public void CheckSkillPrice(float scoreAmount)
   {
      for (var i = 0; i < allGamePlaySkills.Count; i++)
      {
         allGamePlaySkills[i].CheckSkillState(scoreAmount);
      }
   }

   public void UseScoreForSkill(float skillPrice)
   {
      _scoreInfo.UseSkill(skillPrice);
   }
}
