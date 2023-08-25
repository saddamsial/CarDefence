using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BotPlayerData",menuName = "Career/BotPlayerData",order = 1)]
public  class BotPlayerData: ScriptableObject
{
  [SerializeField] private string botCarLocation;


  public string BotCarLocation => botCarLocation;
  
 
}
