using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectLevelPanel : PanelConfiguration
{
    [SerializeField] private Transform content;
    [SerializeField] private LevelButton levelButton;
    [SerializeField] private List<LevelButton> intermediateButtonsList;
    
   

    public override void Show()
    {
        gameObject.SetActive(true);
        foreach (var levelContainer in GlobalCareerContainer.allLevelList)
        {
            LevelButton level = Instantiate(levelButton, content);
            level.Initialize(levelContainer);
            intermediateButtonsList.Add(level);
        }
    }

    public override void Hide()
    {
        gameObject.SetActive(false);
        for (var i = 0; i < intermediateButtonsList.Count; i++)
        {
            Destroy(intermediateButtonsList[i].gameObject);
        }
        
        intermediateButtonsList.Clear();
    }

    public override void ActivateListeners()
    {
        
    }
}
