//Based on Arrow scripts

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireball : MonoBehaviour
{
    public Rigidbody2D rb2d; 
    public float projectileTimer = 1.5f;
    
    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
         projectileTimer -= Time.deltaTime;
         if(projectileTimer <= 0)
         {
             Destroy(gameObject);
             projectileTimer = 1.5f;
         }
    }
    public void LaunchFire(Vector2 direction, float force)
    {
        rb2d.AddForce(direction * force);
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        LinkMovement player = other.gameObject.GetComponent<LinkMovement>();
        Debug.Log("Projectile Collision with " + other.gameObject);
        
        if(player != null)
        {
            player.ChangeHealth(-1);
            Destroy(gameObject);
        }
    }
}
