using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelectFruitUIManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private string fruitType = "";

    private Button startButton;

    private Transform[] fruitUIOptions;
    void Start()
    {
        //startButton = GameObject.Find("Confirm").GetComponent<Button>();
        //startButton.onClick.AddListener(ConfirmFruit);

        fruitUIOptions = GameObject.Find("FruitsContainer").GetComponentsInChildren<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (GetSelectedFruit())
            {
                startButton.interactable = true;
            }
            else
            {
                startButton.interactable = false;
            }
        }

    }

    private bool GetSelectedFruit()
    {
        //Debug.Log("activated");
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;
        foreach (Transform fruit in fruitUIOptions)
        {
            //Debug.Log("iterating");
            if (Physics.Raycast(ray, out hitInfo))
            {
                Debug.Log(hitInfo.transform);
                if (hitInfo.transform == fruit)
                {
                    fruitType = fruit.name;
                    //Debug.Log(fruitType);
                    return true;
                }
            }
        }
        return false;
    }

    public void ConfirmFruit()
    {
        PlayerPrefs.SetString("fruitName", fruitType);
        SceneManager.LoadScene("GameScene_Aidan - Qualifying");
    }
}
