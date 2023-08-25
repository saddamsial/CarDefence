using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameFire : MonoBehaviour
{
    public ParticleSystem ImpactEffect;
    public float BulletDistance = 5;
    public void Fire( int gunDamage)
    {
        if (!ImpactEffect.isPlaying)
        {
            ImpactEffect.Play();
        }
        
        RaycastHit hit;
        var ray = new Ray(transform.position, transform.forward);

        if (Physics.Raycast(ray, out hit, BulletDistance))
        {
            //Apply damage
            hit.transform.gameObject.GetComponent<CarHealBar>().DamagePlayer(gunDamage);
            
        }
    }
}
