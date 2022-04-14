using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
public class Weapon : Collidable
{
    public int damagePoint = 1;
    public float pushForce = 2.0f;
    private Player player;
    private Animator anime;
    private float cooldown = 0.5f;
    private float lastSwing;
    private SpriteRenderer r;


    protected override void Start()
    {
        base.Start();
        anime = GetComponent<Animator>();
        
        player = transform.parent.gameObject.GetComponent<Player>();
    }
    protected override void Update()
    {

        CheckAttack();
        base.Update();

    
    }

    private void CheckAttack()
    {
        if (player.GetShootingState())
        {
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {

            Swing();

        }

        if (Input.GetMouseButtonDown(1))
        {


            Throw();

        }
    }

    private void Swing()
    {
        //  Debug.Log("Swing");

           Debug.Log(player.GetState());

        switch (player.GetState())
        {
            case "down":
             anime.SetTrigger("SwingDown");
            break;

            case "up":
                anime.SetTrigger("SwingUp");
                break;

            case "right":
                anime.SetTrigger("SwingRight");
                break;

            case "left":
                anime.SetTrigger("SwingLeft");
                break;

        }

        
    }

    private void Throw()
    {
        Debug.Log("Throw");
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
    }
}
