using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
  public Transform target;
  private Vector3 posTarget;
  private Vector3 posCamera;


  private void Start()
  {
      posCamera = transform.position;
  }

  private void Update()
  {
      
      posTarget.x = posCamera.x;
      posTarget.y = posCamera.y;
      posTarget.z = target.position.z;
      transform.position = posTarget;
  }
}
