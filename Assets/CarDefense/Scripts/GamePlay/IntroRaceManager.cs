using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;
using UnityEngine.Video;

public class IntroRaceManager : MonoBehaviour
{
   [SerializeField] private PlayerCarForce _playerCarForce;
   [SerializeField] private BotController _botController;
   [SerializeField] private CinemachineVirtualCamera camMove;
   [SerializeField] private PlayableDirector _playableDirector;
   [SerializeField] private Canvas gameCanvas;
   [SerializeField] private TextMeshProUGUI countDownText;
   [SerializeField] private ScoreInfo scoreInfo;
   public NoiseSettings myNoiseProfile ;

   private Transform player;
   private int second = 3;

   public void Initialize(Transform playerTransform)
   {
      player = playerTransform;
      _playableDirector.Play();
      camMove.LookAt = player;
      camMove.Follow = player;
   }

   public void OnFinishTrack()
   {

      StartCoroutine(CountDown());
     
   }

   IEnumerator CountDown()
   {
     
      camMove.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_NoiseProfile = myNoiseProfile;
     
      while (second >=0)
      {
         yield return new WaitForSeconds(1);
         countDownText.text = second.ToString();
         second--;
        
      }
      countDownText.transform.parent.gameObject.SetActive(false);
      gameCanvas.gameObject.SetActive(true);
      FinishCountDown();
   }

   private void FinishCountDown()
   {
      scoreInfo.StartRace();
      _playerCarForce.InitializeMove();
      
      _botController.InitializeMove();


    
   }
}
