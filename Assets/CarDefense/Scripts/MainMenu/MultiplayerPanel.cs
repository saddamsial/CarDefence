using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class MultiplayerPanel : PanelConfiguration
{
    [SerializeField] private InfoPanel infoPanel;
    
    public override void Show()
    {
       gameObject.SetActive(true);
       if(Application.internetReachability == NetworkReachability.NotReachable)
       {
           //Debug.Log("Error. Check internet connection!");
           infoPanel.ShowInfoText("Error. Check internet connection!");
       }
       else
       {
           PhotonNetwork.ConnectUsingSettings();
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
