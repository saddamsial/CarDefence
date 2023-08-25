using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuPanel : PanelConfiguration
{
    
    public void LoadGamePlay()
    {
        SceneManager.LoadScene("City");
    }
    public void LoadDealerShop()
    {
        SceneManager.LoadScene("DealerShop");
    }
    
    public override void Show()
    {
        gameObject.SetActive(true);
       // GarageSpawnCar.SpawnCar(GlobalCarsContainer.currentCar);
    }

    public override void Hide()
    {
        gameObject.SetActive(false);
    }

    public override void ActivateListeners()
    {
       
    }
}
