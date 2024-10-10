using System.IO;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    public static SaveSystem Instance
    {
        get
        {
            return _instance;
        }

        private set { _instance = value; }
    }

    private static SaveSystem _instance;

    public void Awake()
    {
        _instance = this;
        DontDestroyOnLoad(this);
    }


    private string GetSaveFilePath(int slot)
    {
        return Application.persistentDataPath + "/savefile_slot_" + slot + ".json";
    }

    // Save data to a specific slot
    public void Save<T>(T data, int slot)
    {
        string saveFilePath = GetSaveFilePath(slot);
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(saveFilePath, json);
        Debug.Log("Data saved to " + saveFilePath);
    }

    // Load data from a specific slot
    public T Load<T>(int slot) where T : class
    {
        string saveFilePath = GetSaveFilePath(slot);
        if (File.Exists(saveFilePath))
        {
            string json = File.ReadAllText(saveFilePath);
            T data = JsonUtility.FromJson<T>(json);
            Debug.Log("Data loaded from " + saveFilePath);
            return data;
        }
        else
        {
            Debug.LogWarning("Save file not found at " + saveFilePath);
            return null;
        }
    }

    // Check if a save file exists for a given slot
    public bool SaveFileExists(int slot)
    {
        return File.Exists(GetSaveFilePath(slot));
    }
}
