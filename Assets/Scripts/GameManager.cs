using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject playerPrefab;

    [SerializeField]
    private Transform spawnPoint;

    [SerializeField]
    private Transform[] spawnPoints;

    private GameObject currentPlayer;

    //[SerializeField]
    //private PlayerStateManager playerStateManager;

    private void Start()
    {
        SpawnPlayer();
    }

    private void SpawnPlayer()
    {
        var random = new System.Random();
        var randomInt = random.Next(0, spawnPoints.Length - 1);

        spawnPoint = spawnPoints[randomInt];

       // var player = playerStateManager.currentPlayerState;

        if (playerPrefab != null && spawnPoint != null)
        {
            currentPlayer = Instantiate(playerPrefab, spawnPoint.position, spawnPoint.rotation);
            Debug.Log(message: "Player spawned Successfully");
        }
        else
        {
            Debug.Log(message: "Player spawned Failed");
        }
    }
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.R))
        {
            if (currentPlayer != null)
                Destroy(currentPlayer);

            SpawnPlayer();
        }

        //if (Input.GetKeyUp(KeyCode.Space)) 
        //{
        //    playerStateManager.SaveState(currentPlayer.transform);
        //}
    }
}
