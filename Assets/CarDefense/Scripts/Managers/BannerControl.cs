using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public  abstract class BannerControl : MonoBehaviour
{
    public abstract bool VerifyForOpen();


    public abstract void OpenBanner();

    public abstract void ActivateListener();
    

    
}
