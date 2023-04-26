using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Title : MonoBehaviour
{
    public Button playButton;
    public Button exitButton;

    private AudioSource playSound;
    private AudioSource exitSound;

    private bool starting = false;

    // Start is called before the first frame update
    void Start()
    {
        playButton.onClick.AddListener(StartGame);
        exitButton.onClick.AddListener(ExitGame);

        playSound = playButton.GetComponent<AudioSource>();
        exitSound = exitButton.GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        if (starting)
        {
            if (!playSound.isPlaying)
            {
                SceneManager.LoadScene("SelectFruit");
            }
        }
    }

    private void StartGame()
    {
        playSound.Play();
        starting = true;
    }

    private void ExitGame()
    {
        Application.Quit();
    }

}
