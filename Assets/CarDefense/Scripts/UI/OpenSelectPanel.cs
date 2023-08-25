using System.Collections;
using System.Collections.Generic;
using GameAnalyticsSDK;
using UnityEngine;
using UnityEngine.UI;

public class OpenSelectPanel : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField] private PanelType panelType;
    [SerializeField] private bool isClearIntermediaryList;

    private void Awake()
    {
        button.onClick.AddListener(()=>
        {
            PanelsManagerUI.OpenPanel?.Invoke(panelType, isClearIntermediaryList);
            GameAnalytics.NewProgressionEvent(GAProgressionStatus.Complete, "USER_FLOW", "PRESS_BUTTON_FOR_OPEN_"+panelType);
        });
        
    }
}
