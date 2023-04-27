using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class QualiManager : MonoBehaviour
{

    public Transform[] checkpointTransforms;

    public GameObject checkpointObj;
    public GameObject finishlineObj;

    public GameObject timerUI;
    private TextMeshProUGUI timerTMP;

    public GameObject finishSplashUI;
    private TextMeshProUGUI finishSplashTMP;

    private int checkpointIndex;
    private GameObject currentCheckpoint;

    private float timer;
    private bool nowTiming;
    
    // Start is called before the first frame update
    void Start()
    {
        checkpointIndex = 0;
        NextCheckpoint();
        timerTMP = timerUI.GetComponent<TextMeshProUGUI>();
        finishSplashTMP = finishSplashUI.GetComponent<TextMeshProUGUI>();
    }

    public void NextCheckpoint()
    {
        //Destroy the current if it is there
        if (currentCheckpoint != null)
        {
            Destroy(currentCheckpoint);
        }

        //instantiate next checkpoint
        
        //if final point in the array, instantiate finish line
        if (checkpointIndex + 1 == checkpointTransforms.Length)
        {
            currentCheckpoint = Instantiate(finishlineObj, checkpointTransforms[checkpointIndex].position, checkpointTransforms[checkpointIndex].rotation);
        }
        else // instantiate normal checkpoint
        {
            currentCheckpoint = Instantiate(checkpointObj, checkpointTransforms[checkpointIndex].position, checkpointTransforms[checkpointIndex].rotation);
        }

        currentCheckpoint.name = "InstantiatedCheckpoint";
        //increment if it won't exceed the array
        if (checkpointIndex + 1 <= checkpointTransforms.Length)
        {
            checkpointIndex += 1;
        }
    }

    public void StartQuali()
    {
        timer = 0f;
        nowTiming = true;
        timerUI.SetActive(true);
    }

    public void FinishQuali()
    {
        nowTiming = false;
        timerUI.SetActive(false);
        finishSplashUI.SetActive(true);
        finishSplashTMP.SetText("You finished with a time of: " + timer.ToString("F1") + " seconds!");
    }

    private void Update()
    {
        if (nowTiming)
        {
            timer += Time.deltaTime;
            timerTMP.SetText(timer.ToString("F1") + "s");
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            GameObject player = GetComponent<GameManagerInitialisation>().GetPlayer();
            player.transform.position = checkpointTransforms[checkpointIndex - 2].position;
            player.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }
}
