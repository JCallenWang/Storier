using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour, ISavable
{
    public bool IsPlayer = false;

    private SaveSystem saveSystem;

    [Range(1f, 20f)]
    public float speed = 2.0f;
    [Range(1f, 1000f)]
    public float acceleration = 2.0f;

    private float _curSpeed = 0.0f;
    private float _curAcceleration = 0.0f;
    public Rigidbody2D body;

    private Vector2 movement;

    void Start()
    {
        saveSystem = GameObject.FindObjectOfType<SaveSystem>();
    }

    void Update()
    {
        // Input
        if (IsPlayer)
        {
            movement.x = Input.GetAxisRaw("Horizontal");
        }

        if (Input.GetKeyDown(KeyCode.W)) {
            SavePlayer(0);
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            LoadPlayer(0);
        }
    }

    void FixedUpdate()
    {
        // Movement
        body.MovePosition(body.position + movement * speed * Time.fixedDeltaTime);
    }

    // Save Player Data to a specific slot
    public void SavePlayer(int slot)
    {
        saveSystem.Save(SaveData(), slot);
    }

    // Load Player Data from a specific slot
    public void LoadPlayer(int slot)
    {
        var data = saveSystem.Load<PlayerData>(slot);
        if (data != null)
        {
            LoadData(data);
        }
    }

    // Implement SaveData from ISavable
    public object SaveData()
    {
        // Save current level and player position
        return new PlayerData(transform.position);
    }

    // Implement LoadData from ISavable
    public void LoadData(object data)
    {
        PlayerData playerData = data as PlayerData;
        if (playerData != null)
        {
            // Load level and position
            transform.position = playerData.position;
            Debug.Log("Player position loaded: " + playerData.position);
        }
    }
}
