using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject fireballPrefab;
    SpriteRenderer skull;
    Transform point;
    public float radius;
    private Player player;
    public float fireballForce;
    public void Start()
    {
        point = GetComponent<Transform>();
        player = transform.parent.gameObject.GetComponent<Player>();
        point.localPosition = new Vector3(radius, 0f, 0f);
        skull = GetComponent<SpriteRenderer>();

    }

    private void SetupPoint(Vector3 position)
    {
     //   point.position = PlaceOnCircle(position);
       
    }

    private void PlaceOnCircle(Vector3 position)
    {
      
        Ray ray = Camera.main.ScreenPointToRay(position);
        
        Vector3 pos = ray.GetPoint(0f);

        pos = transform.parent.InverseTransformPoint(pos);

      
        
      
        float angle = Mathf.Atan2(pos.x, pos.y);
       
      
        pos.x = radius * Mathf.Sin(angle);
        pos.y = radius * Mathf.Cos(angle);
        pos.z = 0f;
        point.localPosition = pos;
     
    }


    private void ShooFireBall()
    {
        Debug.Log("sss");
        Vector3 pew = point.position - player.transform.position;

        
        GameObject fireball = Instantiate(fireballPrefab, point.position, point.rotation);
        Rigidbody2D rb = fireball.GetComponent<Rigidbody2D>();

        var angle = (Mathf.Atan2(pew.y, pew.x) * Mathf.Rad2Deg) + 90f;
       
       
        fireball.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);




        Debug.Log(pew);
        rb.AddRelativeForce(pew * fireballForce);
    }

    private void Update()
    {
        if (!player.GetShootingState())
        {
            skull.enabled = false;
            return;
        }
        skull.enabled = true;
        PlaceOnCircle(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            ShooFireBall();
        }
    }
}
