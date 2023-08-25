using System;
using UnityEngine;
using System.Collections;

public class FPSFireManager : MonoBehaviour
{
    public ImpactInfo[] ImpactElemets = new ImpactInfo[0];
    [Space] public float BulletDistance = 100;
    public ParticleSystem ImpactEffect;


    public void Fire(int gunDamage)
    {
        RaycastHit hit;
        var ray = new Ray(transform.position, transform.forward);

        if (Physics.Raycast(ray, out hit, BulletDistance))
        {
            if (ImpactEffect.isPlaying)
            {
                ImpactEffect.Stop();
            }
            ImpactEffect.Play();
            var effect = GetImpactEffect(hit.transform.gameObject);
            if (effect == null)
                return;
            var effectIstance = Instantiate(effect, hit.point, new Quaternion(),hit.transform) as GameObject;
            effectIstance.transform.LookAt(hit.point + hit.normal);
            Destroy(effectIstance, 20);
            
            //Apply damage
            hit.transform.gameObject.GetComponent<CarHealBar>().DamagePlayer(gunDamage);
            
        }
    }


    private void OldFire()
    {
        // RaycastHit hit;
        // var ray = new Ray(transform.position, transform.forward);
        // if (Physics.Raycast(ray, out hit, BulletDistance))
        // {
        //     var impactEffectIstance = Instantiate(ImpactEffect, transform.position, transform.rotation,transform) as GameObject;
        //
        //     Destroy(impactEffectIstance, 4);
        //     
        //     var effect = GetImpactEffect(hit.transform.gameObject);
        //     if (effect == null)
        //         return;
        //     var effectIstance = Instantiate(effect, hit.point, new Quaternion(),hit.transform) as GameObject;
        //     effectIstance.transform.LookAt(hit.point + hit.normal);
        //     Destroy(effectIstance, 20);
        //     Debug.Log("Effec Instance work");
        //
        //   
        // }
    }
    

    [System.Serializable]
    public class ImpactInfo
    {
        public MaterialType.MaterialTypeEnum MaterialType;
        public GameObject ImpactEffect;
    }

    GameObject GetImpactEffect(GameObject impactedGameObject)
    {
       
        var materialType = impactedGameObject.GetComponent<MaterialType>();
        if (materialType == null)
            return null;
        foreach (var impactInfo in ImpactElemets)
        {
            if (impactInfo.MaterialType == materialType.TypeOfMaterial)
                return impactInfo.ImpactEffect;
        }

        return null;
    }
}