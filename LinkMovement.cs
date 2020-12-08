// https://learn.unity.com/tutorial/audio-muz?uv=2019.2&projectId=5c6166dbedbc2a0021b1bc7c#5d77a737edbc2a08aca818b5
// This script is based on the RubyController script found under the check your script section of the linked tutorial page

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LinkMovement : MonoBehaviour
{
    public float speed = 5f;
    public int maxHealth = 3;
    public int health { get { return currentHealth; } }
    public int currentHealth;
    float horizontal;
    float vertical;
    public Vector2 lookDirection = new Vector2(1,0);
    float timeRed = .5f;
    Rigidbody2D rb2d;
    bool isHit = false;
    public GameObject arrowPrefab;
    public GameObject arrowPrefabRight;
    public GameObject arrowPrefabRightTrue;
    public GameObject arrowPrefabDown;
    float attackTimer = .75f;
    bool activeTimer = false;
    Vector2 startPosition = new Vector2(0,0);

    public Animator animator;
    
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        // Taken from Ruby 2D tutorial. Some small changes were made, specifically using GetAxisRaw to disable motion smoothing
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        Vector2 move = new Vector2(horizontal, vertical);
        
        if(!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
        {
            lookDirection.Set(move.x, move.y);
            lookDirection.Normalize();
        }
        //print(lookDirection.x);
        //print(lookDirection.y);
        if(lookDirection.x != 0 && lookDirection.y != 0)
        {
            speed = 3.5f;
        }
        else
        {
            speed = 5f;
        }

        animator.SetFloat("Horizontal", lookDirection.x);
        animator.SetFloat("Vertical", lookDirection.y);
        animator.SetFloat("Speed", move.magnitude);
        

        if(Input.GetKeyDown(KeyCode.Space))
        {    
            if(activeTimer == false)        
            {   
                if(lookDirection.x < 0 && lookDirection.y > 0)
                {
                    LaunchArrowDown();
                }
                if(lookDirection.x > 0 && lookDirection.y > 0)
                {
                    LaunchArrow();
                    //activeTimer = true;
                }
                else if(lookDirection.y < 0 && lookDirection.x > 0)
                {
                    LaunchArrowDown();
                    //activeTimer = true;
                }
                else if(lookDirection.y < 0 && lookDirection.x < 0)
                {
                    LaunchArrowDown();
                    //activeTimer = true;
                }
                else if(lookDirection.y > 0 && lookDirection.x == 0)
                {
                    LaunchArrow();
                    //activeTimer = true;
                }
                else if(lookDirection.x < 0 && lookDirection.y == 0)
                {
                    LaunchArrowRight();
                    //activeTimer = true;
                }
                else if(lookDirection.x > 0 && lookDirection.y == 0)
                {
                    LaunchArrowRightTrue();
                    //activeTimer = true;
                }
                else //(lookDirection.y < 0 && lookDirection.x == 0)
                {
                    LaunchArrowDown();
                // activeTimer = true;
                }
            }
            activeTimer = true;
        }
        if(activeTimer == true)
        {
            attackTimer -= Time.deltaTime;
            if(attackTimer <= 0)
            {
                activeTimer = false;
                attackTimer = .75f;
            }
        }
    print(activeTimer);

        if (Input.GetKeyDown(KeyCode.X))
        {
            RaycastHit2D hit = Physics2D.Raycast(rb2d.position + Vector2.up * 0.2f, lookDirection, 1.5f, LayerMask.GetMask("NPC"));
            if (hit.collider != null)
            {
                NonPlayerCharacter character = hit.collider.GetComponent<NonPlayerCharacter>();
                if (character != null)
                {
                    character.DisplayDialog();
                    StartCoroutine(ExampleCoroutine());
                }
            }
        }
    }

    // https://youtu.be/lrmNnwhOjgM
    IEnumerator ExampleCoroutine()
    {
        yield return new WaitForSeconds(2);
        AppHelper.Quit();
    }
    // Also taken from Ruby. Moves link and prevents stuttering when Link's collider hits another collider
    void FixedUpdate()
    {
        if(currentHealth != 0)
        {    Vector2 position = transform.position;
            position.x = position.x + speed * horizontal * Time.deltaTime;
            position.y = position.y + speed * vertical * Time.deltaTime;
            rb2d.MovePosition(position);
        }

       if(isHit)
       {
           timeRed -= Time.deltaTime;
       }
        if(currentHealth <= 0)
        {
            transform.position = startPosition;
            currentHealth = maxHealth;
        }
        if(timeRed <= 0)
        {
            // https://answers.unity.com/questions/1367570/how-to-make-enemies-flash-on-hit.html adapted from the linked answer
            GetComponent<Renderer>().material.color = Color.white;
            timeRed = 0.5f;
            isHit = false;
        }
        print(currentHealth);
    }
    // https://answers.unity.com/questions/11641/how-do-i-rotate-a-projectile.html transform.position taken from linked answer
    void LaunchArrow()
    {
        GameObject arrowObject = Instantiate(arrowPrefab, transform.position, gameObject.transform.rotation);
        ArrowUp arrowUp = arrowObject.GetComponent<ArrowUp>();
        arrowUp.LaunchArrow(lookDirection, 700);
    }
    void LaunchArrowRight()
    {
        GameObject arrowObject = Instantiate(arrowPrefabRight, transform.position, gameObject.transform.rotation);
        ArrowRight arrowRight = arrowObject.GetComponent<ArrowRight>();
        arrowRight.LaunchArrowRight(lookDirection, 700);
    }
    void LaunchArrowRightTrue()
    {
        GameObject arrowObject = Instantiate(arrowPrefabRightTrue, rb2d.position + Vector2.up * 0.3f, gameObject.transform.rotation);
        ArrowRightTrue arrowRightTrue = arrowObject.GetComponent<ArrowRightTrue>();
        arrowRightTrue.LaunchArrowRightTrue(lookDirection, 700);
    }
    void LaunchArrowDown()
    {
        GameObject arrowObject = Instantiate(arrowPrefabDown, rb2d.position - Vector2.up * 1.1f, gameObject.transform.rotation);
        ArrowDown arrowDown = arrowObject.GetComponent<ArrowDown>();
        arrowDown.LaunchArrowDown(lookDirection, 700);
    }
    public void ChangeHealth(int amount)
    {
        if (currentHealth + amount < currentHealth)
        {   timeRed -= Time.deltaTime;
            // https://answers.unity.com/questions/1367570/how-to-make-enemies-flash-on-hit.html adapted from the linked answer
            GetComponent<Renderer>().material.color = Color.red;
            isHit = true;
        }
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        UIHealthBar.instance.SetValue(currentHealth / (float)maxHealth);
        if(currentHealth == 0)
        {
             UIHealthBar.instance.SetValue(maxHealth/(float)maxHealth );
        }

    }
}
