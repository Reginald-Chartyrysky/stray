using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class Player : Hittable
{

    public Sprite state_up;
    public Sprite state_down;
    public Sprite state_left;
    public Sprite state_right;
    private string player_state;
    private Vector3 direction;
    private BoxCollider2D player_collider;
    private SpriteRenderer player_sprite;
    private RaycastHit2D hit;
    private bool isShooting;
    private ICinemachineCamera eye;
    void Start()
    {
        isShooting = false;
        player_collider = GetComponent<BoxCollider2D>();
        player_sprite = GetComponent<SpriteRenderer>();
        player_state = "down";
        eye = GameObject.Find("Dynamic Camera").GetComponent<CinemachineVirtualCamera>();
    }

   
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            isShooting = true;
            
            eye.Follow = GetComponentInChildren<Shoot>().gameObject.transform;
        }
        else
        {
            isShooting = false;
           
        }

            if (!isShooting)
        {
            eye.Follow = transform;
            float x = Input.GetAxisRaw("Horizontal");
            float y = Input.GetAxisRaw("Vertical");
            Vector3 moveDelta = new Vector3(x * (float)4, y * (float)4, 0);



            SetDirection(moveDelta);
            ChangeState();
            if (moveDelta != Vector3.zero)
            {

                MovePlayerIfPossible(moveDelta);

            }
        }
       


    }


    public bool GetShootingState()
    {
        return isShooting;
    }

    void SetDirection(Vector3 moveDelta)
    {

   

        if ( (moveDelta.x == direction.x && moveDelta.y == direction.y) && direction != Vector3.zero )
            return;

        if (moveDelta.x == 0 && moveDelta.y == 0)
        {
            return;
           
        }

        if (moveDelta.x == 0 || moveDelta.y == 0)
        {
            direction.y = moveDelta.y;
            direction.x = moveDelta.x;
        }

      
    }


    public string GetState()
    {
        return player_state;
    }

    void ChangeState()
    {
        
        if (direction.x < 0)
        { 
            player_sprite.sprite = state_left;
            player_state = "left";
            return;
        }
        if (direction.x > 0)
        {
            player_sprite.sprite = state_right;
            player_state = "right";
            return;
        }
        if (direction.y < 0) 
        { 
            player_sprite.sprite = state_down;
            player_state = "down";
            return;
        }
           
        if (direction.y > 0) 
        { 
            player_sprite.sprite = state_up;
            player_state = "up";
            return;
        }
           
    }
    void MovePlayerIfPossible(Vector3 moveDelta)
    {

        hit = Physics2D.BoxCast(transform.position, player_collider.size, 0, new Vector2(0, moveDelta.y), Mathf.Abs(moveDelta.y * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));
        if (hit.collider == null)
        { transform.Translate(0, moveDelta.y * Time.deltaTime, 0); }

        hit = Physics2D.BoxCast(transform.position, player_collider.size, 0, new Vector2(moveDelta.x, 0), Mathf.Abs(moveDelta.x * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));
        if (hit.collider == null)
        { transform.Translate(moveDelta.x * Time.deltaTime, 0, 0); }

    }
}
