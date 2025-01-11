using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class PlayerState
{
    public string playerName;
    public int level;
    public float health;
    public Vector3 position;
    public Quaternion rotation;
    public int[] inventory;

    public void Save(string filePath)
    {
        try
        {
            string json = JsonUtility.ToJson(this, true);
            System.IO.File.WriteAllText(filePath, json);
            Debug.Log(message: $"Player state saved to {filePath}");
        }
        catch (Exception ex)
        {
            Debug.LogError(message: $"Failed to save player state: {ex.Message}");
        }

    }

    public static PlayerState Load(string filePath)
    {
        try
        {
            if (System.IO.File.Exists(filePath))
            {
                string json = System.IO.File.ReadAllText(filePath);
                return JsonUtility.FromJson<PlayerState>(json);
            }
            else
            {
                Debug.LogWarning($"File not found: {filePath} ");
                return null;
            }
        }
        catch (Exception ex)
        {
            Debug.LogError(message: $"Failed to load player state: {ex.Message}");
            return null;
        }
    }
}