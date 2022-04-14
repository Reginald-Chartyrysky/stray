using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Collidable
{
    public Sprite closed;
    public Sprite opened;
    bool open = false;



    protected override void Interact(Collider2D hit)
    {
        

        
        if (hit.name == "Player")
        {
            open = true;
            thisSprite.sprite = opened;
        }

        

       
    }


    protected override void Update()
    {
        open = false;
        base.Update();
        if (!open)
        {
            thisSprite.sprite = closed;
        }
    }
    


}
