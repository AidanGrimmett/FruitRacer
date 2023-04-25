using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointScript : MonoBehaviour
{
    private GameObject gameManager;

    private bool istriggered = false;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager");    
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!istriggered && other.tag == "Player")
        {
            gameManager.GetComponent<QualiManager>().NextCheckpoint();
            istriggered = true;
        }
    }
}
