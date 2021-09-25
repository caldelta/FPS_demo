using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBarrel : HitObject
{
    public GameObject ImpactHole;
    public GameObject ExplosiveVfx;

    public override void Hit()
    {
        if (RaycastHit.collider != null)
            Debug.LogError(RaycastHit.collider.gameObject.name);
        GameObject.Instantiate(ImpactHole, RaycastHit.point, Quaternion.LookRotation(RaycastHit.normal));

        var hitObject = RaycastHit.collider.gameObject;

        if(hitObject.GetComponent<ExplosiveBarrel>() != null)
            hitObject.GetComponent<ExplosiveBarrel>().SetHitType(HitType);

        if (hitObject.GetComponent<Rigidbody>() != null)
        {
            GameObject.Instantiate(ExplosiveVfx, hitObject.transform.position, hitObject.transform.rotation);
            hitObject.GetComponent<Rigidbody>().AddForce(hitObject.transform.forward * 100, ForceMode.Impulse);
        }
    }
}
