using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class ScoreInfo : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreCoefficientText;
    [SerializeField] private TextMeshProUGUI scoreText;
  //  [SerializeField] private NosUseManger nosUseManger;
    [SerializeField] private SkillsManagerGamePlay _skillsManagerGamePlay;
    
    
    [Header("Changes stats")]
    public bool givePoint;
    public int scoreСoefficient = 2;
  
    
    public float scoreAmount;



    private bool isStartRace;
    private bool canUseNos;


    private void Start()
    {
        scoreСoefficient =  ES3.Load(SaveKeys.IapScoreAddСoefficient,0) +  ES3.Load(SaveKeys.ScoreAddСoefficient + GlobalCarsContainer.currentCar.CarId, 2);
        scoreCoefficientText.text = "X" + scoreСoefficient;
    }

    private void Update()
    {
        
        if (givePoint && isStartRace)
        {
            scoreAmount += scoreСoefficient;
           

        }

        _skillsManagerGamePlay.CheckSkillPrice(scoreAmount);
       
        
        scoreText.text = scoreAmount.ToString();
    }


    public void StartRace()
    {
        isStartRace = true;
    }
    public void UseSkill(float price)
    {
        scoreAmount -= price;
    }
}
