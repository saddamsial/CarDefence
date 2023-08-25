using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum UpgradeCarType
{
    Mass,
    Torque,
}
public class UpgradePanel : PanelConfiguration
{
    [SerializeField] private CarComponents carComponents;
    [SerializeField] private UpgradeButton wheelsUpgrade;
    [SerializeField] private UpgradeButton bodyUpgrade;
    
    public override void Show()
    {
      gameObject.SetActive(true);
      carComponents.rigid.isKinematic = true;
    }

    public void Initialize(CarComponents carComp)
    {
        carComponents = carComp;
        wheelsUpgrade.Initialize(carComp.wheelsUpgradePoint);
        bodyUpgrade.Initialize(carComp.bodyUpgradePoint);
    }
    
    
    
    public override void Hide()
    {
        gameObject.SetActive(false);
        if (carComponents)
        {
            carComponents.rigid.isKinematic = false;
        }
    }

    public override void ActivateListeners()
    {
        wheelsUpgrade.ActivateListener();
        bodyUpgrade.ActivateListener();
    }
}
