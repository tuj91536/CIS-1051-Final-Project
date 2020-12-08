// https://learn.unity.com/tutorial/visual-styling-ui-head-up-display?uv=2019.2&projectId=5c6166dbedbc2a0021b1bc7c#5d6559afedbc2a0020986e55
// This scripts is based on the UIHealthBar script found under the check your scripts section of the linked tutorial page
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHealthBar : MonoBehaviour
{
    public static UIHealthBar instance { get; private set; }

    public Image mask;
    float originalSize;

    public void Awake()
    {
        instance = this;
    }

    public void Start()
    {
        originalSize = mask.rectTransform.rect.width;
    }

    public void SetValue(float value)
    {
        mask.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, originalSize * value);
    }
}