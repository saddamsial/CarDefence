using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FirstSceneLoadManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
      //  ES3.Save(SaveKeys.OpenMemberShipBanner, true);
        StartCoroutine(LoadMainMenuScene());
    }

    IEnumerator LoadMainMenuScene()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("MainMenu");
    }

   
}
