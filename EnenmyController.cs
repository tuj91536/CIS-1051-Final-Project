// https://learn.unity.com/tutorial/world-interactions-projectile?uv=2019.2&projectId=5c6166dbedbc2a0021b1bc7c#5c7f8528edbc2a002053b3f3
// This script is based on the EnemyController script found under the check your script section of the linked tutorial page

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnenmyController : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    public bool vertical;
    public float changeTime = 3.0f;
    public float maxHealth = 1f;
    float currentHealth;

    Rigidbody2D rigidbody2D;
    float timer;
    int direction = 1;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        timer = changeTime;
        currentHealth = maxHealth;
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer < 0)
        {
            direction = -direction;
            timer = changeTime;
        }
    }

    void FixedUpdate()
    {
        Vector2 position = rigidbody2D.position;

        if (vertical)
        {
            position.y = position.y + Time.deltaTime * speed * direction; ;
        }
        else
        {
            position.x = position.x + Time.deltaTime * speed * direction; ;
        }
        rigidbody2D.MovePosition(position);

        if(currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
    void OnCollisionEnter2D(Collision2D other)
{
    LinkMovement player = other.gameObject.GetComponent<LinkMovement>();

    ArrowDown arrowDown = other.gameObject.GetComponent<ArrowDown>();
    ArrowUp arrowUp = other.gameObject.GetComponent<ArrowUp>();
    ArrowRight arrowRight = other.gameObject.GetComponent<ArrowRight>();
    ArrowRightTrue arrowRightTrue = other.gameObject.GetComponent<ArrowRightTrue>();
    if(arrowDown != null)
    {
        currentHealth -= 1f;
        https://answers.unity.com/questions/1367570/how-to-make-enemies-flash-on-hit.html adapted from the linked answer
        GetComponent<Renderer>().material.color = Color.red;
    }
    if(arrowUp != null)
    {
        currentHealth -= 1f;
        GetComponent<Renderer>().material.color = Color.red;
    } 
    if(arrowRight != null)
    {
        currentHealth -= 1f;
        GetComponent<Renderer>().material.color = Color.red;
    }
    if(arrowRightTrue != null)
    {
        currentHealth -= 1f;
        GetComponent<Renderer>().material.color = Color.red;
    }
    //if (player != null)

    if (player != null)
    {
        player.ChangeHealth(-1);
    }
}
}
