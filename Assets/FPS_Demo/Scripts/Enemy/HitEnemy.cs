using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEnemy : HitObject
{
    public GameObject BloodSplash;
    public override void Hit()
    {
#if DEBUG
        if (RaycastHit.collider != null)
            Debug.LogError(RaycastHit.collider.gameObject.name);
#endif
        GameObject.Instantiate(BloodSplash, RaycastHit.point, Quaternion.LookRotation(RaycastHit.normal));

        var hitObject = RaycastHit.collider.gameObject;        

        if (hitObject.GetComponent<Rigidbody>() != null)
        {
            hitObject.GetComponent<Rigidbody>().AddForce(-hitObject.transform.forward * 100, ForceMode.Impulse);            
        }

        hitObject.GetComponent<EnemyHealth>().Damage(PlayerConst.ATTACK_DAMAGE);
    }
}
