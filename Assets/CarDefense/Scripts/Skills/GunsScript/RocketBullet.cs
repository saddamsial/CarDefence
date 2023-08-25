using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class RocketBullet : MonoBehaviour
{
  

    [SerializeField] private Rigidbody rigid;
    [SerializeField] private GameObject explosion;
    private bool isBoomOnCollision; // if rocket enter in two collision
    
    private int damage;

        public void InitializeMove(Transform rayCastOrigin, int skillStatsBulletDamage)
        {
            damage = skillStatsBulletDamage;
            
            rigid.AddForce(0,0 ,40,ForceMode.Impulse);
            
        // RaycastHit hit;
        // var ray = new Ray(rayCastOrigin.position, rayCastOrigin.forward);
        //
        //
        //
        // if (Physics.Raycast(ray, out hit, 1000))
        // {
        //     Debug.Log(hit.transform.gameObject.name + " Hit object");
        //    
        //  
        //     rigid.AddForce(0,0 ,40,ForceMode.Impulse);
        //
        // } else
        // {
        //     transform.DOMove(new Vector3(0,10,0), 5).SetEase(Ease.OutCirc).OnComplete(MakeBigBoom);
        // }
        
    }
        
    

        private void OnCollisionEnter(Collision other)
        {
            if (!isBoomOnCollision)
            {
                if (other.gameObject.GetComponent<RCC_CarControllerV3>())
                {
                    other.gameObject.GetComponent<CarHealBar>().DamagePlayer(damage);
                    isBoomOnCollision = true;
                }
                MakeBigBoom(); 
            }
         
        }
        
    private void MakeBigBoom()
    {
        //TODO MAKE BOOM
        GameObject boom = Instantiate(explosion,transform.position,Quaternion.identity);
        Destroy(boom,2);
        Debug.Log("MakeBOOM");
        Destroy(gameObject);
    }
}
