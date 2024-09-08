using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

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

    [Header("load Scene")]
    public bool canLoadScene;
    public string toLoadSceneName;


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

    private IEnumerator ChangeColor(bool isbackward)
    {
        float elapsedTime = 0f;
        Color startColor = currColor;
        while(elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / duration;
            if (!isbackward)
            {
                currColor = Color.Lerp(startColor, hoverColor, t);
            }
            else
            {
                currColor = Color.Lerp(startColor, defaultColor, t);
            }
            this.gameObject.GetComponent<TMP_Text>().color = currColor;
            //Debug.Log($"currColor: {currColor}, ratio: {t}");
            yield return null;
        }

        // Ensure the final color is set
        if (!isbackward)
        {
            this.gameObject.GetComponent<TMP_Text>().color = hoverColor;
        }
        else
        {
            this.gameObject.GetComponent<TMP_Text>().color = defaultColor;
        }
    }

    public void LoadSceneWithName()
    {
        if (canLoadScene)
        {
            StartCoroutine(LoadSceneAsync(toLoadSceneName));
        }
    }
    private IEnumerator LoadSceneAsync(string scene)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(scene);
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
