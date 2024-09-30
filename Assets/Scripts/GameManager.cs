using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

[RequireComponent(typeof(EventFlagManager))]
public class GameManager : MonoBehaviour
{
    public PointerManger _pointerManager;
    public PlayerController PlayerController;
    public EventFlagManager EventFlagManager;
    private WorldData _worldData;

    private void Awake()
    {
        if (_pointerManager != null)
        {
            DontDestroyOnLoad(_pointerManager);
        }
        DontDestroyOnLoad(this.gameObject);
        EventFlagManager = GetComponent<EventFlagManager>();
    }


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.W))
        {
            EventFlagManager.SetEventFlag("flag1", true);
            WorldData worldData = new WorldData();
            worldData.playerData = PlayerController.SaveData() as PlayerData;
            worldData.eventFlagData = EventFlagManager.SaveData() as EventFlagSystemData;
            
            SaveSystem.Instance.Save<WorldData>(worldData, 0);
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            WorldData worldData = SaveSystem.Instance.Load<WorldData>(0);
            PlayerController.LoadData(worldData.playerData);
            EventFlagManager.LoadData(worldData.eventFlagData);
        }
    }

}
