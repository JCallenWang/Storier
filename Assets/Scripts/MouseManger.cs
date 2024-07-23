using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseManger : MonoBehaviour
{
    public string filterLayer;
    
    
    private int UILayer;


    private void Start()
    {
        UILayer = LayerMask.NameToLayer(filterLayer);
    }

    // Update is called once per frame
    void Update()
    {
        GetCurrentHoverObject();
    }

    public GameObject GetCurrentHoverObject()
    {
        return isPointerOverUIElement(GetEventSystemRaycastResults());
    }

    private GameObject isPointerOverUIElement(List<RaycastResult> eventSystemRaycastResults)
    {
        foreach(var i in eventSystemRaycastResults)
        {
            if(i.gameObject.layer == UILayer)
            {
                Debug.Log($"Mouse is hovering {i.gameObject.name}");
                return i.gameObject;
            }
        }
        return null;
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
