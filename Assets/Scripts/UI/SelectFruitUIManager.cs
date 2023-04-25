using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectFruitUIManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private string fruitType;

    private Transform[] fruitUIOptions;
    void Start()
    {
        fruitUIOptions = GameObject.Find("FruitsContainer").GetComponentsInChildren<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GetSelectedFruit();
        }
    }

    private void GetSelectedFruit()
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
                    Debug.Log(fruitType);
                }
            }
        }
    }
}
