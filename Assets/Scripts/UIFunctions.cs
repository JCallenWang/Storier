using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class UIFunctions : MonoBehaviour
{
    [Header("Color Changed")]
    public bool isColorChanged;
    public Color hoverColor;
    public float duration;
    private Color defaultColor;
    private Color currColor;
    private Coroutine currColorCoroutine;


    [Header("Size Changed")]
    public bool isSizeChanged;
    public float scaleRatio;

    private void Start()
    {
        defaultColor = this.gameObject.GetComponent<TMP_Text>().color;
        currColor = defaultColor;
    }

    public void OnPointerEnter()
    {
        Debug.Log($"Mouse is enter {this.gameObject.name}");
        if (isColorChanged)
        {
            if(currColorCoroutine != null)
            {
                StopCoroutine(currColorCoroutine);
            }
            currColorCoroutine = StartCoroutine(ChangeColor(false));
        }
    }

    public void OnPointerExit()
    {
        Debug.Log($"Mouse is exit {this.gameObject.name}");
        if (isColorChanged)
        {
            StopCoroutine(currColorCoroutine);
            currColorCoroutine = StartCoroutine(ChangeColor(true));
        }
    }

    public void OnPointerHover()
    {
        Debug.Log($"Mouse is hover {this.gameObject.name}");
    }

    IEnumerator ChangeColor(bool isbackward)
    {
        float elapsedTime = 0f;
        while(elapsedTime <= duration)
        {
            elapsedTime += Time.deltaTime / duration;
            if (!isbackward)
            {
                currColor = Color.Lerp(currColor, hoverColor, elapsedTime);
            }
            else
            {
                currColor = Color.Lerp(currColor, defaultColor, elapsedTime);
            }
            this.gameObject.GetComponent<TMP_Text>().color = currColor;
            Debug.Log($"currColor: {currColor}, Elapsed Time: {elapsedTime}");
            yield return null;
        }
    }
}
