using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAPPanel : PanelConfiguration
{
    [SerializeField] private List<MenuIapButton> menuIapButtons;
    public override void Show()
    {
        gameObject.SetActive(true);
        for (var i = 0; i < menuIapButtons.Count; i++)
        {
            menuIapButtons[i].Initialize();
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
