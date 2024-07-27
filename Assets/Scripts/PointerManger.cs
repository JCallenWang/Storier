using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PointerManger : MonoBehaviour
{
    private GameObject currGameObject;

    private void Update()
    {
        isPointerOverUIElement(GetEventSystemRaycastResults());
    }

    private void CheckUIElementBehavior(GameObject nextGameObject)
    {
        //Debug.Log($"CheckUIElementBehavior been called, nextGameObject: {nextGameObject}");
        UIFunctions component;
        if (currGameObject == nextGameObject)
        {
            if((component = currGameObject.GetComponent<UIFunctions>()) != null)
            {
                component.OnPointerHover();
            }
            return;
        }

        if (currGameObject != null && (component = currGameObject.GetComponent<UIFunctions>()) != null)
        {
            component.OnPointerExit();
        }


        if (nextGameObject != null && (component = nextGameObject.GetComponent<UIFunctions>()) != null)
        {
            component.OnPointerEnter();
        }

        currGameObject = nextGameObject;
    }

    private void isPointerOverUIElement(List<RaycastResult> eventSystemRaycastResults)
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
