using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EventFlagData
{
    public string key;
    public bool value;

    public EventFlagData(string key, bool value)
    {
        this.key = key;
        this.value = value;
    }
}

[System.Serializable]
public class EventFlagSystemData
{
    public List<EventFlagData> serialData;  

    public EventFlagSystemData(Dictionary<string,bool> data)
    {
        serialData = new List<EventFlagData>();

        foreach(string key in data.Keys)
        {
            serialData.Add(new EventFlagData(key, data[key]));
        }
    }
}
