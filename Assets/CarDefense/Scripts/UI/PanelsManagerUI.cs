using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PanelsManagerUI : MonoBehaviour
{
    public static Action<PanelType, bool> OpenPanel;
    public static Action Back;

    [SerializeField] protected List<PanelConfiguration> panelConfigurationList;
    [SerializeField] protected Button backButton;
    protected readonly List<PanelConfiguration> intermediaryPanelList = new List<PanelConfiguration>();

    protected PanelConfiguration currentPanel;

    public bool isNeedBackButton;
    protected virtual void Awake()
    {
        backButton.onClick.AddListener(BackButton);
        ActivateListeners();

        HidePanels();
        OpenPanel += OpenCurrentPanel;
        Back += BackButton;
 
    }

    protected virtual void ActivateListeners()
    {
        foreach (PanelConfiguration panelConfiguration in panelConfigurationList)
        {
            panelConfiguration.ActivateListeners();
        }
    }


    protected virtual void OnDestroy()
    {
        OpenPanel -= OpenCurrentPanel;
        Back -= BackButton;
    }

    protected virtual void HidePanels()
    {
        foreach (PanelConfiguration panelConfiguration in panelConfigurationList)
        {
            panelConfiguration.Hide();
        }
    }

    protected virtual void OpenCurrentPanel(PanelType panelType, bool clearList)
    {
        PanelConfiguration newPanel = panelConfigurationList.Find(e => e.Type == panelType);
        currentPanel?.Hide();


        currentPanel = newPanel;

        currentPanel.Show();

        if (clearList)
        {
            intermediaryPanelList.Clear();
        }
        // if (currentPanel != newPanel)
        // {
        //    
        // }


        CheckToAddIntermediaryList(panelType, newPanel);

        CheckIntermediaryPanelListState();
    }


    protected virtual void CheckToAddIntermediaryList(PanelType panelType, PanelConfiguration newPanel)
    {
        if (intermediaryPanelList.Count <= 0)
        {
            intermediaryPanelList.Add(newPanel);
        }
        else
        {
            if (intermediaryPanelList.Last().Type != panelType)
            {
                intermediaryPanelList.Add(newPanel);
            }
        }
    }
    
    protected virtual void BackButton()
    {
        intermediaryPanelList.Last().Hide();
        intermediaryPanelList.Remove(intermediaryPanelList.Last());
        intermediaryPanelList.Last().Show();
        currentPanel = intermediaryPanelList.Last();
        CheckIntermediaryPanelListState();
    }


    public virtual void CheckIntermediaryPanelListState()
    {
        backButton.onClick.RemoveAllListeners();
        backButton.gameObject.SetActive(false);
       
        if (intermediaryPanelList.Count <=1)
        {
            if (isNeedBackButton)
            {
                backButton.gameObject.SetActive(true);
                backButton.onClick.AddListener(() =>
                {
                    SceneManager.LoadScene("MainMenu");
                });
            }
          
        }
        else
        {
            backButton.gameObject.SetActive(intermediaryPanelList.Count > 1);
            backButton.onClick.AddListener(BackButton);
        }
       
    }

  
}