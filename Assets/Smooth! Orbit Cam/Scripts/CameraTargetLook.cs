using System;
using Cinemachine;
using UnityEngine;

namespace Scripts
{
    public class CameraTargetLook : MonoBehaviour
    {
        [SerializeField] private CinemachineBrain cinemachineBrain;
        [SerializeField] private SmoothOrbitCam smoothOrbitCam;
        private void Update()
        {
            
            smoothOrbitCam.target = cinemachineBrain.ActiveVirtualCamera.VirtualCameraGameObject.transform;
        }
    }
}
