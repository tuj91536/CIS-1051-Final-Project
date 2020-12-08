// This script is adapted from the EnemyController script used in this project

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy2 : MonoBehaviour
{
       // Start is called before the first frame update
    public float speed;
    bool vertical;
    public float changeTime = 3.0f;
    public float maxHealth = 2;
    float currentHealth;
    public GameObject firePrefab;
    public Vector2 fireDirection = new Vector2(0,-1);

    Rigidbody2D rigidbody2D;
    float timer;
    float fireTimer = 1f;
    int direction = 1;
    int switchCheck = 0;

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
        fireTimer -= Time.deltaTime;
        if(fireTimer <= 0)
        {
            LaunchFire();
            fireTimer = 1f;
        }
        if (timer <= 0)
        {
            direction = -direction;
            timer = changeTime;
            switchCheck += 1;
        }
        
        if(switchCheck == 2)
        {
            if(vertical == false)
            {
                vertical = true;
                direction = -direction;
            }
            else
            {
                vertical = false;
            }
            switchCheck = 0;
        }
       
        print(switchCheck);
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
            //https://answers.unity.com/questions/1367570/how-to-make-enemies-flash-on-hit.html adapted from the linked answer
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
        if (player != null)
        {
            player.ChangeHealth(-1);
        }
    }
    void LaunchFire()
    {
        GameObject fireObject = Instantiate(firePrefab, rigidbody2D.position - Vector2.up * .5f, Quaternion.identity);
        fireball fireball = fireObject.GetComponent<fireball>();
        fireball.LaunchFire(fireDirection, 700);
    }
}
