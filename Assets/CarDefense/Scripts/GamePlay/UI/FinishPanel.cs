using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Photon.Pun;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishPanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI finishText;
    [SerializeField] private TextMeshProUGUI winCoinsText;
    [SerializeField] private TextMeshProUGUI farmingCoinsText;


    public void Initialize(bool value,float farmingCoins)
    {
        gameObject.SetActive(true);
        GameCurrencyManager.FarmingCoins += farmingCoins;
        farmingCoinsText.text = $"You get {farmingCoins} FarmingCoins <sprite index=[0]>";
        if (value)
        {
            finishText.text = "You Win";
            GameCurrencyManager.WinCoins += 1;
            winCoinsText.text = "You get 1 WinCoins <sprite index=[2]>";
            
        }
        else
        {
            finishText.text = "You Lose";
            winCoinsText.text = "No win No coin <sprite index=[2]>";
        }
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
     
       
    }
    public void Continue()
    {
        Time.timeScale = 1f;
        int currentLevelIndex = GlobalCareerContainer.currentLevel.LevelIndex;
        if (currentLevelIndex < GlobalCareerContainer.allLevelList.Last().LevelIndex)
        {
            GlobalCareerContainer.allLevelList.Find(e=>e.LevelIndex == currentLevelIndex+1).StartLevel(); 
        }
        else
        {
            SceneManager.LoadScene("MainMenu");
        }
       
    }
    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
        PhotonNetwork.Disconnect();
        
    }
}
