// https://learn.unity.com/tutorial/world-interactions-projectile?uv=2019.2&projectId=5c6166dbedbc2a0021b1bc7c#5c7f8528edbc2a002053b3f3
// This script is based on the Projectile script found under the check your script section of the linked tutorial page
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowDown : MonoBehaviour
{
public Rigidbody2D rb2d;
 
    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        if(transform.position.magnitude > 1000.0f)
        {
            Destroy(gameObject);
        }
    }
    public void LaunchArrowDown(Vector2 direction, float force)
    {
        rb2d.AddForce(direction * force);
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Projectile Collision with " + other.gameObject);
        Destroy(gameObject);
    }
}
