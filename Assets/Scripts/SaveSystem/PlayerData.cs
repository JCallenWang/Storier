using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public Vector3 position;

    public PlayerData(Vector3 position)
    {
        this.position = position;
    }
}
