using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class Enemy : Hittable
{

    private AIPath path;
    float boop;
    protected void Start()
    {
    
        hitPoint = maxHitPoint;
        path = GetComponent<AIPath>();

        boop = transform.localScale.x;
    }
    

    private void Update()
    {

       

        if (path.desiredVelocity.x >= 0.01f)


        {
            transform.localScale = new Vector3(-boop, transform.localScale.y, transform.localScale.z);
        }
        else if(path.desiredVelocity.x <= -0.01f)
        {
            transform.localScale = new Vector3(boop, transform.localScale.y, transform.localScale.z);
        }
    }
    protected override void ReceiveDamage(Damage dmg)
    {
        hitPoint -= dmg.damageAmount;
        if (hitPoint <= 0)
        {
            Death();
        }
        Debug.Log(hitPoint);
    }

    protected override void Death()
    {
          Destroy(gameObject);
       
    }
}
