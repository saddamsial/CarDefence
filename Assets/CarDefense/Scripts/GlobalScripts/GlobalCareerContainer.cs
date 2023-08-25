using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class GlobalCareerContainer
{
   public static List<LevelContainer> allLevelList = new List<LevelContainer>();
   public static LevelContainer currentLevel;

   [RuntimeInitializeOnLoadMethod]
   static void Initialize()
   {
      allLevelList = Resources.LoadAll<LevelContainer>(PathLocation.LevelContainerLocation).ToList();
      allLevelList = allLevelList.OrderBy(e => e.LevelIndex).ToList();
   }
}
