using UnityEngine;

public enum PanelType
{
    MainMenuPanel,
    DealerShipPanel,
    IapPanel,
    GameModePanel,
    SelectLevelPanel,
    MultiPlayerPanel,
    UpgradePanel,
    PlayerSkillsPanel,
}

public abstract class PanelConfiguration : MonoBehaviour
{
    [SerializeField] protected PanelType panelType;

    public PanelType Type => panelType;

    public abstract void Show();
    public abstract void Hide();

    public abstract void ActivateListeners();
}