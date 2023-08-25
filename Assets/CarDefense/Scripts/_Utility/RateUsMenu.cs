using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
#if UNITY_IOS
using UnityEngine.iOS;
#endif

public class RateUsMenu : MonoBehaviour
{
    // Linkul jocului in google play
    [SerializeField] private string googlePlayLink;
    
    [SerializeField] private Button yesButton;
    [SerializeField] private Button noButton;
    
    public GameObject[] stars;
    public Sprite star_full, star_null;

    
    private void Awake()
    {
        yesButton.onClick.AddListener(RateUsYes);
        noButton.onClick.AddListener(RateUsNo);
    }

    private void OnEnable()
    {
        SetStarRaycast(true);
    }

    private void OnDisable()
    {
        // SetStarRaycast(false);
        // Highlight(0);
    }

    #region Star Colloring
    
    public void Highlight(int index)
    {
        for (int i = 0; i < stars.Length; i++)
        {
            if (i < index)
                stars[i].GetComponent<Image>().sprite = star_full;
            else
                stars[i].GetComponent<Image>().sprite = star_null;
        }
    }

    private void SetStarRaycast(bool status)
    {
        for (int i = 0; i < stars.Length; i++)
        {
            stars[i].GetComponent<Image>().raycastTarget = status;
        }
    }
    #endregion
    
    #region Rating
    
    private void RateUsYes()
    {
        Debug.LogError("Oppened LINK");
        
        if (Application.platform == RuntimePlatform.IPhonePlayer)
        {
#if UNITY_IOS
            Device.RequestStoreReview();
#endif
        }
        if (Application.platform == RuntimePlatform.Android)
        {
            Application.OpenURL(googlePlayLink);//"https://play.google.com/store/apps/details?id=com.brandpremium.truckdriverusa");
        }
        
        PlayerPrefs.SetInt("RateUs", 1);
        PlayerPrefs.SetInt("RateUs_AppStore", 1);
       // StartCoroutine(CloseRateUs(0.5f));
       gameObject.SetActive(false);
    }
    
    private void RateUsNo()
    {
      //  Debug.LogError("Oppened Not Link");
        
        //PlayerPrefs.SetInt("RateUs", 1);
        gameObject.SetActive(false);
        //StartCoroutine(CloseRateUs(0.5f));
    }
    private IEnumerator CloseRateUs(float t)
    {
        yield return new WaitForSeconds(t);
        gameObject.SetActive(false);
    }
    
    public void RateStar(int s)
    {
        PlayerPrefs.SetInt("UserRatedUs", s);
        
        if (s <= 3) 
            StartCoroutine(CloseRateUs(0.5f));
        else
            RateUsYes();
    }
    #endregion
    
}
