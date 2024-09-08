using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class PointerManger : MonoBehaviour
{
    private GameObject currGameObject;
    public Action<GameObject> OnPointerEnter;
    public Action<GameObject> OnPointerExit;
    public Action<GameObject> OnPointerHover;
    
    private void Update()
    {
        CheckIsOverUIElement(GetEventSystemRaycastResults());
    }

    private void CheckUIElementBehavior(GameObject nextGameObject)
    {
        //Debug.Log($"CheckUIElementBehavior been called, nextGameObject: {nextGameObject}");
        UIFunctions component;
        if (currGameObject == nextGameObject)
        {
            OnPointerHover?.Invoke(nextGameObject);
            if((component = currGameObject.GetComponent<UIFunctions>()) != null)
            {
                component.OnPointerHover();
            }
            return;
        }

        if (currGameObject != null && (component = currGameObject.GetComponent<UIFunctions>()) != null)
        {
            OnPointerExit?.Invoke(currGameObject);
            component.OnPointerExit();
        }


        if (nextGameObject != null && (component = nextGameObject.GetComponent<UIFunctions>()) != null)
        {
            OnPointerEnter?.Invoke(nextGameObject);
            component.OnPointerEnter();
        }

        currGameObject = nextGameObject;
    }

    private void CheckIsOverUIElement(List<RaycastResult> eventSystemRaycastResults)
    {
        foreach(var i in eventSystemRaycastResults)
        {
            //Debug.Log($"foreach i({i}) in eventSystemRaycastResults");
            if (i.gameObject.GetComponent<UIFunctions>() != null)
            {
                CheckUIElementBehavior(i.gameObject);
            }
        
        }

        if (eventSystemRaycastResults.Count == 0)
        {
            if(currGameObject != null)
            {
                CheckUIElementBehavior(null);
            }
        }
    }
    private static List<RaycastResult> GetEventSystemRaycastResults()
    {
        PointerEventData eventData = new PointerEventData(EventSystem.current);
        eventData.position = Input.mousePosition;
        List<RaycastResult> raycastResults = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, raycastResults);
        return raycastResults;
    }

}
