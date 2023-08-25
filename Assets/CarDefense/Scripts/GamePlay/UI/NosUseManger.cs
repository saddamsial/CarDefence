using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class NosUseManger : MonoBehaviour
{
    [SerializeField] private Button nosButton;
    [SerializeField] private ScoreInfo scoreInfo;
    [SerializeField] private TextMeshProUGUI nitroTimesText;
    [SerializeField] private TextMeshProUGUI nitroPriceText;
    public int scoreAmount;

    [FormerlySerializedAs("nitroPrice")] [Header("Changes stats")]
    public int nosPrice;
    [FormerlySerializedAs("nitroTimes")] public int nosTimes;


    private bool isActivateNitro;

    private void Start()
    {
        nosTimes = ES3.Load(SaveKeys.IapNosCharges,0)+ ES3.Load(SaveKeys.NosCharges + GlobalCarsContainer.currentCar.CarId, 2);
        nosPrice = ES3.Load(SaveKeys.IapNosPrices ,0) + ES3.Load(SaveKeys.NosPrices + GlobalCarsContainer.currentCar.CarId, 1000);
        nosButton.onClick.AddListener(UseNos);
        nitroTimesText.text = "X" + nosTimes;
        nitroPriceText.text = nosPrice.ToString();
    }

    private void Update()
    {
        if (scoreAmount >= nosPrice && !isActivateNitro)
        {
            nosButton.interactable = true;
            isActivateNitro = true;
        }
        else if (scoreAmount < nosPrice && isActivateNitro)
        {
            nosButton.interactable = false;
            isActivateNitro = false;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            nosButton.onClick.Invoke();
        }
    }

    private void UseNos()
    {
       scoreInfo.UseSkill(nosPrice);
       nosTimes -= 1;
       nitroTimesText.text = "X" + nosTimes;
       if (nosTimes <= 0)
       {
           nosButton.gameObject.SetActive(false);
       }
    }
    
  
}
