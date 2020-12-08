// https://learn.unity.com/tutorial/world-interactions-dialogue-raycast?uv=2019.2&projectId=5c6166dbedbc2a0021b1bc7c#5d5d2dc1edbc2a002035a9a4
// This script is based on the NonPlayerCharacter script found in the check your scripts section of the linked tutorial page

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonPlayerCharacter : MonoBehaviour
{
    public float displayTime = 4.0f;
    public GameObject dialogBox;
    float timerDisplay;

    void Start()
    {
        dialogBox.SetActive(false);
        timerDisplay = -1.0f;
    }

    void Update()
    {
        if (timerDisplay >= 0)
        {
            timerDisplay -= Time.deltaTime;
            if (timerDisplay < 0)
            {
                dialogBox.SetActive(false);
            }
        }
    }

    public void DisplayDialog()
    {
        timerDisplay = displayTime;
        dialogBox.SetActive(true);
    }
}