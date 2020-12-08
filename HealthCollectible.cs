// https://learn.unity.com/tutorial/audio-muz?uv=2019.2&projectId=5c6166dbedbc2a0021b1bc7c#5d77a737edbc2a08aca818b5
// This script is based on the HealthCollectible script found under the check your script section of the linked tutorial page
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectible : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        LinkMovement controller = other.GetComponent<LinkMovement>();

        if (controller != null)
        {
            if (controller.health < controller.maxHealth)
            {
                controller.ChangeHealth(1);
                Destroy(gameObject);
            }
        }
    }
}
