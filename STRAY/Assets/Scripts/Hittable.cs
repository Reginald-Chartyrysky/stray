using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hittable : MonoBehaviour
{
    public int hitPoint;
    public int maxHitPoint;
    public float pushRecoverySpeed = 0.2f;

    //protected float immuneTime = 1.0f;
    //protected float lastImmune;

    protected Vector3 pushDirection;

    protected virtual void ReceiveDamage(Damage dmg) 
    {

    }

    protected virtual void Death() { }
}
