using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : Collidable
{
    public int damagePoint = 1;
    public float pushForce = 2.0f;


    void Dispose()
    {
        Destroy(gameObject);
    }
    protected override void Interact(Collider2D hit)
    {
       
        if (hit.tag == "Enemy")
        {

           
            Damage dmg = new Damage()
            {
                damageAmount = damagePoint,
                origin = transform.position,
                pushForce = pushForce
            };

            hit.SendMessage("ReceiveDamage", dmg);
           
        }
        
            Dispose();
        
    }
}
