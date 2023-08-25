using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuPanlesManager : PanelsManagerUI
{
    // Start is called before the first frame update
    void Start()
    {
        OpenPanel?.Invoke(PanelType.MainMenuPanel,false);
    }

   
}
