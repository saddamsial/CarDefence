using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;

public class RoomListingsMenu : MonoBehaviourPunCallbacks
{
    [SerializeField] private LobbyManager lobbyManager;
    [SerializeField] private Transform _content;
    [SerializeField] private RoomListing _roomListing;
    [SerializeField] private Button playWithRoomName;
    [SerializeField] private InfoPanel infoPanel;


    private List<RoomListing> _listings = new List<RoomListing>();

    private object betValue;

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
       
        foreach (RoomInfo info in roomList)
        {
            //Removed from rooms list.


            int index = _listings.FindIndex(x => x.RoomInfo.Name == info.Name);
            if (index != -1)
            {
                Destroy(_listings[index].gameObject);
                _listings.RemoveAt(index);
            }

            // Added to rooms list.
            if (!info.RemovedFromList)
            {
                RoomListing listing = Instantiate(_roomListing, _content);
                if (listing != null)
                    listing.SetRoomInfo(info);  
                listing.startRoom.onClick.AddListener(() =>
                {
                    lobbyManager.QuickStartOnButton(info.Name, 0);
                });
                _listings.Add(listing);

                // if (listing.RoomInfo.CustomProperties.TryGetValue("bet", out betValue))
                // {
                //     int betInt = (int) betValue;
                //     listing.startRoom.onClick.AddListener(() =>
                //     {
                //         lobbyManager.QuickStartOnButton(info.Name, betInt);
                //     });
                // }
            }
        }

        CheckRoomExist();
    }


    public void FindRoomByName(string roomName)
    {
        foreach (var rListing in _listings)
        {
            if (rListing.RoomInfo.Name == roomName)
            {
                if (rListing.RoomInfo.CustomProperties.TryGetValue("bet", out betValue))
                {
                    int betInt = (int) betValue;
                    playWithRoomName.onClick.AddListener(() =>
                    {
                        lobbyManager.QuickStartOnButton(roomName, betInt);
                    });
                }

                break;
            }
        }
    }

    public void CheckRoomExist()
    {
        if (_listings.Count == 0)
        {
           infoPanel.ShowInfoText("No rooms found");
        }
        else if(_listings.Count > 0)
        {
            infoPanel.gameObject.SetActive(false);
        }
    }
}