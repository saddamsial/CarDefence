using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfinityMenuRoad : MonoBehaviour
{


    public static Action LoadNextRoad;
    [SerializeField] private GameObject menuRoad;
    [SerializeField] private List<GameObject> roadsList = new List<GameObject>();
    [SerializeField] private int distance;
    
   
    // Start is called before the first frame update
    void Start()
    {
        LoadNextRoad += LoadRoad;
    }

    private void OnDestroy()
    {
        LoadNextRoad -= LoadRoad;
    }

    private void LoadRoad()
    {
        GameObject road = Instantiate(menuRoad, Vector3.zero, Quaternion.identity);
        roadsList.Add(road);
       int index =  roadsList.FindIndex(e => e.gameObject == road);
        road.transform.position = new Vector3(0,0,roadsList[index-1].transform.position.z + distance);
        CheckRoadsCount();
    }


    private void CheckRoadsCount()
    {
        if (roadsList.Count >= 3)
        {
            Destroy(roadsList[0]);
            roadsList.Remove(roadsList[0]);
        }
    }
  
}
