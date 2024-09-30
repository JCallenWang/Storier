using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Simple Event Flag system
/// [TODO] load different levels
/// [TODO] save and load
/// </summary>
/// 
[System.Serializable]
public class EventFlagManager : MonoBehaviour, ISavable
{
    private Dictionary<string, bool> eventFlags = new Dictionary<string, bool>();

    // Set a condition flag
    public void SetEventFlag(string eventName, bool status)
    {
        if (!eventFlags.ContainsKey(eventName))
        {
            eventFlags.Add(eventName, status);
        }
        else
        {
            eventFlags[eventName] = status;
        }

    }

    // Check if a condition is met
    public bool CheckCondition(string condition)
    {
        return eventFlags.ContainsKey(condition) && eventFlags[condition];
    }

    // Check multiple conditions using variadic parameters
    public bool CheckConditions(params string[] conditions)
    {
        foreach (string condition in conditions)
        {
            if (!CheckCondition(condition))
            {
                return false;  // One condition is not met
            }
        }
        return true;  // All conditions are met
    }

    public object SaveData()
    {
        return new EventFlagSystemData(eventFlags);
    }

    public void LoadData(object data)
    {
        EventFlagSystemData flagData = data as EventFlagSystemData;
        if (flagData != null)
        {
            foreach(EventFlagData item in flagData.serialData)
            {
                eventFlags.Clear();
                Debug.Log("item=" + item.key);
                eventFlags.Add(item.key, item.value);
            }
        }
    }
}

