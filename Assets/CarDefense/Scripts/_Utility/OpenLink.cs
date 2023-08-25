using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenLink : MonoBehaviour
{
    [SerializeField] private Button openLinkButton;
    [SerializeField] private string linkForOpen;
    void Start()
    {
        openLinkButton.onClick.AddListener(OpenLinkOnButton);
    }

    private void OpenLinkOnButton()
    {
        Application.OpenURL(linkForOpen);
      
    }
   
}
