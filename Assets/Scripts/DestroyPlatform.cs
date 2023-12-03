using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPlatform : MonoBehaviour
{
    public float respawnTime = 5f; // Time in seconds before respawn
    private bool playerCollided = false;

    public GameObject tempObject;
    private void Start()
    {
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !playerCollided)
        {
            playerCollided = true;
            Break();
            Invoke("RespawnPlatform", respawnTime);
        }
    }

    void Break()
    {
        // You can add any additional effects or logic before destroying the platform
        Destroy(gameObject, 2f);
    }

    void RespawnPlatform()
    {
        // Instantiate a new instance of the platform or reset its state
        // Adjust the position and other parameters as needed
        tempObject = (GameObject)Instantiate(Resources.Load("tempObject") as GameObject);

        // Reset the flag for future collisions
        playerCollided = false;
    }
}
