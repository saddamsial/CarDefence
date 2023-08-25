using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameModePanel : PanelConfiguration
{

    public override void Show()
    {
       gameObject.SetActive(true);
    }

    public override void Hide()
    {
        gameObject.SetActive(false);
    }

    public override void ActivateListeners()
    {
       
    }
}
