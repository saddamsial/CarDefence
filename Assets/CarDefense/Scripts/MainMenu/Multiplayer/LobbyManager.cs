using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using Random = UnityEngine.Random;

public class LobbyManager : MonoBehaviourPunCallbacks
{
    [SerializeField] private InfoPanel infoPanel;
    [SerializeField] private int RoomSize = 2;
    
    public override void OnConnectedToMaster()
    {
        PhotonNetwork.SendRate = 45;
        PhotonNetwork.SerializationRate = 15;
        PhotonNetwork.AutomaticallySyncScene = true;
      
        PhotonNetwork.JoinLobby();

        ES3.Save(SaveKeys.GameMode,GameModeType.OnlineMode);
        Debug.Log("S-o conectat");

        // SetCustomProperties();
        //Syncronize Tuning 



    }

    private void SetCustomProperties()
    {
        Hashtable hash = new Hashtable();
        
        // hash.Add("WheelIndex",carTuningIndex.wheels);
        // hash.Add("SkirtIndex",carTuningIndex.skirt);
        // hash.Add("AirInTakeIndex",carTuningIndex.airInTake);
        // hash.Add("SpoilerIndex",carTuningIndex.spoiler);
        // hash.Add("BumperFrontIndex",carTuningIndex.bumperFront);
        // hash.Add("BumperRearIndex",carTuningIndex.bumperRear);
        // hash.Add("VinilIndex",carTuningIndex.vinilSprites);
        // hash.Add("CurrentCarIndex", GlobalCarsContainer.CurrentCar.CarId);
        // hash.Add("CurrentColor", new Vector3(carTuningIndex.carBodyColor.r,carTuningIndex.carBodyColor.g,carTuningIndex.carBodyColor.b) );
        // hash.Add("WheelsColor",new Vector3(wheelsColor.r,wheelsColor.g,wheelsColor.b));
        // PhotonNetwork.SetPlayerCustomProperties(hash);
    }
    public void CreateRoom( int bet)
    {
        RoomOptions roomOps = new RoomOptions() {IsVisible = true, IsOpen = true, MaxPlayers = (byte) RoomSize};
        // Set roomInfo property
        // roomOps.CustomRoomPropertiesForLobby = new string[1] {ROOM_BET_FOR_PLAY};
        // roomOps.CustomRoomProperties = new Hashtable { { ROOM_BET_FOR_PLAY, bet } };
        // PlayerPrefs.SetInt(SaveKeys.BetForRace, bet);
        int randomRoomNumber = Random.Range(0, 10000); // creating a random name for the room
        PhotonNetwork.CreateRoom( randomRoomNumber.ToString(), roomOps, TypedLobby.Default); 
        infoPanel.ShowInfoText("Waitng for other player to start the most  awesome batlle in your life ");
       // Debug.Log("Quick start");
    }
    
    
    public void QuickStartOnButton(string name , int b)
    {
        RoomOptions roomOps = new RoomOptions() {IsVisible = true, IsOpen = true, MaxPlayers = (byte) RoomSize};
        PhotonNetwork.JoinRoom(name); // First tries to join an existing room
        Debug.Log("Quick start");
        
        // if (b <= GameCurrencyManager.Money)
        // {
        //     loadingButton.SetActive(true);
        //     createButton.SetActive(false);
        //     PlayerPrefs.SetInt(SaveKeys.BetForRace, b);
        //     RoomOptions roomOps = new RoomOptions() {IsVisible = true, IsOpen = true, MaxPlayers = (byte) RoomSize};
        //     PhotonNetwork.JoinRoom(name); // First tries to join an existing room
        //     Debug.Log("Quick start");
        // }
        // else
        // {
        //     noMoneyPanel.SetActive(true);
        // }
    }
    
    public override void OnJoinedRoom()
    {
        
        if (PhotonNetwork.IsMasterClient)
        {
            
            StartCoroutine(CheckPlayerCount());
        }
      

    }
    
    IEnumerator CheckPlayerCount()
    { 
       
        yield return new WaitUntil(() => PhotonNetwork.CurrentRoom.PlayerCount == 2 );
        StartGame();
    }
    
    private void StartGame()
    {

       
        if (PhotonNetwork.IsMasterClient)
        {
            PhotonNetwork.LoadLevel("City");
            // switch (sceneIndex)
            // {
            //     case 0 :
            //         PhotonNetwork.LoadLevel("Night");
            //         break;
            //     case 1:
            //         PhotonNetwork.LoadLevel("GoldenGates");
            //         break;
            //     case 2:
            //         PhotonNetwork.LoadLevel("DubaiMultiplayer");
            //         break;
            // }
          
        }
    }

    
    
}
