// https://answers.unity.com/questions/161858/startstop-playmode-from-editor-script.html
// https://youtu.be/lrmNnwhOjgM


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wait : MonoBehaviour
{
    void Start()
    {
        //Start the coroutine we define below named ExampleCoroutine.
        StartCoroutine(ExampleCoroutine());
    }

    IEnumerator ExampleCoroutine()
    {
        yield return new WaitForSeconds(4);
        AppHelper.Quit();
    }
}