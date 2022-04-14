using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collidable : MonoBehaviour
{

    public ContactFilter2D filter;
    private Collider2D thisCollider;
    protected SpriteRenderer thisSprite;
    private Collider2D[] hits = new Collider2D[10];
    
    
    protected virtual void Start()
    {
        thisCollider = GetComponent<Collider2D>();
        thisSprite = GetComponent<SpriteRenderer>();
    }


    protected virtual void Update()
    {
        thisCollider.OverlapCollider(filter, hits);

        for (int i = 0; i < hits.Length; i++)
        {
            if (hits[i] == null)
                continue;

            Interact(hits[i]);
            hits[i] = null;
        }
    }

    protected virtual void Interact(Collider2D hit)
    {
       
    }
}
