using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BannersManager : MonoBehaviour
{
    [SerializeField] private List<BannerControl> bannersControlList;
    

    void Start()
    {
        ActivateBannersListener();
       
    }

    private void ActivateBannersListener()
    {
        for (int i = 0; i < bannersControlList.Count; i++)
        {

            bannersControlList[i].ActivateListener();
        }
        VerifyBannerForOpen();
    }

    private void VerifyBannerForOpen()
    {
        for (int i = 0; i < bannersControlList.Count; i++)
        {

            if (bannersControlList[i].VerifyForOpen())
            {
                bannersControlList[i].OpenBanner();
                break;
            }
        }
    }

   
}
