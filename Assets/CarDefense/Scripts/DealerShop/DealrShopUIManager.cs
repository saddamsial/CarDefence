using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealrShopUIManager : PanelsManagerUI
{
    private void Start()
    {
        PanelsManagerUI.OpenPanel?.Invoke(PanelType.DealerShipPanel,false);
    }
    
    
}
