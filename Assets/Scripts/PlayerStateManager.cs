using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateManager : MonoBehaviour
{
    private const string SaveFilePath = "playerState.json";
    public PlayerState currentPlayerState;

    private void Awake()
    {
       
        var loadedState = PlayerState.Load(SaveFilePath);

        if(loadedState != null)
        {
            currentPlayerState = loadedState;
            ApplyPlayerState();
        }
        else
        {
            currentPlayerState = new PlayerState
            {
                playerName = "Player 1",
                level = 1,
                health = 100,
                position = Vector3.zero,
                rotation = Quaternion.identity,
                inventory = new int[] { 101, 102, 103 }// example of item ids

            };

            SaveState(transform);
            ApplyPlayerState();
        }
    }
    public void SaveState(Transform currentPlayerTransform)
    {
        currentPlayerState.position = currentPlayerTransform.position;
        currentPlayerState.rotation = currentPlayerTransform.rotation;

        currentPlayerState.Save(SaveFilePath);
    }
    private void ApplyPlayerState()
    {
        transform.position = currentPlayerState.position;
        transform.rotation = currentPlayerState.rotation;

        Debug.Log($" Loaded the Player state: {currentPlayerState.playerName} Level {currentPlayerState.level}");
    }
}
