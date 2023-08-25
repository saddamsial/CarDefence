using System.Collections;
using System.Collections.Generic;
using Photon.Realtime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RoomListing : MonoBehaviour
{
    public Button startRoom;
    public RoomInfo RoomInfo { get; private set; }
       [SerializeField]
       private TextMeshProUGUI _text;

       private object betValue;

       private bool isFull;

   
       public void SetRoomInfo(RoomInfo roomInfo)
       {
           RoomInfo = roomInfo;

           if (roomInfo.CustomProperties.TryGetValue("bet", out betValue))
           {
              // Debug.Log(betValue.ToString());
               _text.text = "ROOM NAME" + roomInfo.Name + "                                                                    " + roomInfo.PlayerCount + "/2" + "                                " + (int) betValue;
               
           }

           if (roomInfo.PlayerCount == 2 && !isFull)
           {
               startRoom.interactable = false;
               isFull = true;
           }   
           
       }
}
