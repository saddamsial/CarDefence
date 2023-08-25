using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class MenuIapButton : MonoBehaviour
{
   [SerializeField] private List<IAPItem> iapItems;
   [SerializeField] private Button buyIapButton;
   [SerializeField] private TextMeshProUGUI iapLevel;
   private IAPItem currentIap;

   
   public void Initialize()
   {
      if (iapItems.Exists(e => e.CheckBuyStat() == false))
      {
         for (var i = 0; i < iapItems.Count; i++)
         {
            if (iapItems[i].CheckBuyStat() == false)
            {
               currentIap = iapItems[i];
               break;
            }
         }

         SetButtonUi();
      }
      else
      {
         gameObject.SetActive(false);
      }
     
   }

   private void SetButtonUi()
   {
      buyIapButton.onClick.RemoveAllListeners();
      buyIapButton.onClick.AddListener(()=> IAPManager.instance.Buy(currentIap.Identifier));
      iapLevel.text = $"{currentIap.Identifier} - price =  {currentIap.PriceText} ";
   }
}
