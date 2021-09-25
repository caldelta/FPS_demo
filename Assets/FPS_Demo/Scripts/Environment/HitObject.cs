using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitObject
{
    public RaycastHit RaycastHit { get; set; }
    public int HitType { get; set; }

    public virtual void Hit() { }

    public void SetType(int type)
    {
        HitType = type;
    }
}
