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
    private RectTransform[] fruitBgImages;

    public AudioSource selectSound;
    public AudioSource startSound;

    private bool starting = false;

    void Start()
    {
        startButton = GameObject.Find("Confirm").GetComponent<Button>();
        //startButton.onClick.AddListener(ConfirmFruit);

        fruitUIOptions = GameObject.Find("FruitsContainer").GetComponentsInChildren<Transform>();
        fruitBgImages = GameObject.Find("FruitBg").GetComponentsInChildren<RectTransform>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (GetSelectedFruit())
            {
                foreach (RectTransform image in fruitBgImages)
                {
                    if (image.name != "FruitBg")
                    {
                        image.gameObject.GetComponent<RawImage>().enabled = false;
                        if (image.name == fruitType)
                        {
                            image.gameObject.GetComponent<RawImage>().enabled = true;
                        }
                    }
                }

                startButton.interactable = true;
            }
        }

        if (starting)
        {
            if (!startSound.isPlaying)
            {
                SceneManager.LoadScene("GameScene_Aidan - Qualifying");
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
                    selectSound.Play();
                    //Debug.Log(fruitType);
                    return true;
                }
            }
        }
        return false;
    }

    public void ConfirmFruit()
    {
        starting = true;
        startSound.Play();
        PlayerPrefs.SetString("fruitName", fruitType);
    }
}
