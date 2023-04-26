using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManagerInitialisation : MonoBehaviour
{
    public GameObject[] fruits;
    public GameObject startLocation;

    public bool doCountdown;
    private float countdownDuration = 3f;
    private float timer;

    private GameObject player = null;

    public GameObject countdownUI;
    private TextMeshProUGUI countdownText;

    private void Start()
    {
        //this won't happen when the menu does it :p
        //PlayerPrefs.SetString("fruitName", "apple");

        //retrieve the chosen fruit obj name
        string selectedFruitName = PlayerPrefs.GetString("fruitName");

        // Find the selected character prefab based on its name
        GameObject selectedPlayerPrefab = null;
        foreach (GameObject fruit in fruits)
        {
            if (fruit.name == selectedFruitName)
            {
                selectedPlayerPrefab = fruit;
                break;
            }
        }

        // Spawn the selected character in the game
        player = Instantiate(selectedPlayerPrefab, startLocation.transform.position, startLocation.transform.rotation);
        
        if (doCountdown)
        {
            timer = countdownDuration;
            countdownUI.SetActive(true);
            countdownText = countdownUI.GetComponent<TextMeshProUGUI>();
            countdownText.SetText("3");
        }
    }

    private void Update()
    {
        if (doCountdown)
        {
            if (timer >= countdownDuration && !player.GetComponent<Rigidbody>().isKinematic)
            {
                player.GetComponent<NewPlayerMovement>().Freeze();
            }

            if (timer <= 2f && timer > 1f && countdownText.text != "2")
            {
                countdownText.SetText("2");
            }
            else if (timer <= 1f && timer > 0f && countdownText.text != "1")
            {
                countdownText.SetText("1");
            }
            else if (timer <= 0f && timer > -1f && countdownText.text != "Go!")
            {
                countdownText.SetText("Go!");
                player.GetComponent<NewPlayerMovement>().Defrost();
                GetComponent<QualiManager>().StartQuali();
            }
            else if (timer <= -1f)
            {
                doCountdown = false;
                countdownUI.SetActive(false);
            }
            timer -= Time.deltaTime;
        }
    }

    public GameObject GetPlayer()
    {
        return player;
    }
}
