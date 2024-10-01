using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Finds all of the gameObjects that have a ParallaxLayer.cs script, and moves them!*/

public class ParallaxController : MonoBehaviour
{
    public delegate void ParallaxCameraDelegate(float cameraPositionChangeX, float cameraPositionChangeY);
    public ParallaxCameraDelegate onCameraMove;
    private Vector2 _prevCameraPosition;
    List<ParallaxLayer> _parallaxLayers = new List<ParallaxLayer>();

    Camera cam;

    void Start()
    {
        cam = Camera.main;
        onCameraMove += MoveLayer;
        FindLayers();
        _prevCameraPosition.x = cam.transform.position.x;
        _prevCameraPosition.y = cam.transform.position.y;
    }

    private void Update()
    {
        if (onCameraMove != null)
        {
            Vector2 cameraPositionChange;
            cameraPositionChange = new Vector2(cam.transform.position.x - _prevCameraPosition.x, cam.transform.position.y- _prevCameraPosition.y);
            onCameraMove(cameraPositionChange.x, cameraPositionChange.y);
        }

        _prevCameraPosition = new Vector2(cam.transform.position.x, cam.transform.position.y);
    }

    //Finds all the objects that have a ParallaxLayer component, and adds them to the parallaxLayers list.
    void FindLayers()
    {
        _parallaxLayers.Clear();

        for (int i = 0; i < transform.childCount; i++)
        {
            ParallaxLayer layer = transform.GetChild(i).GetComponent<ParallaxLayer>();

            if (layer != null)
            {
                _parallaxLayers.Add(layer);
            }
        }
    }

    //Move each layer based on each layers position. This is being used via the ParallaxLayer script
    void MoveLayer(float positionChangeX, float positionChangeY)
    {
        foreach (ParallaxLayer layer in _parallaxLayers)
        {
            layer.MoveLayer(positionChangeX, positionChangeY);
        }
    }
}