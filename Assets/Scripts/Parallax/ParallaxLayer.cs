using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Allows the controller to move each layer based on the parallaxAmount!*/

public class ParallaxLayer : MonoBehaviour
{
    [Range(-1f, 1f)]
    public float ratio = 0;
    
    [System.NonSerialized] 
    public Vector3 newPosition;
    
    public void MoveLayer(float positionChangeX, float positionChangeY)
    {
        newPosition = transform.localPosition;
        newPosition.x += positionChangeX * ratio;
        newPosition.y += positionChangeY * ratio;
        transform.localPosition = newPosition;
    }

}
