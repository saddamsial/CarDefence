using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarHealBar : MonoBehaviour
{
    [SerializeField] private Image carHealBar;
    
    public float playerHealPoints;
    public float currentPlayerHeal;
    
    
    public void Initialize(int playerHealP)
    {
        playerHealPoints = playerHealP;
        currentPlayerHeal = playerHealP;
       
    }

    public void SetCarHealBar(Image healBar)
    {
        carHealBar = healBar;
    }
   
   

    public void DamagePlayer(int damage)
    {
        currentPlayerHeal -= damage;
        carHealBar.fillAmount = currentPlayerHeal / playerHealPoints;

    }
}
