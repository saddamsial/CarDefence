using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InfoPanel : MonoBehaviour
{
   [SerializeField] private TextMeshProUGUI infoText;
   
   public void ShowInfoText(string info)
   {
      gameObject.SetActive(true);
      infoText.text = info;
   }
}
