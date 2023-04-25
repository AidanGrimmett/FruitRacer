using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using UnityEngine.UI;

public class FruitChanger : NetworkBehaviour
{
    public List<GameObject> fruits;

    public void SetFruit(string fruitName)
    {
        foreach (GameObject fruit in fruits)
        {
            if (fruit.name.ToLower().Contains(fruitName))
            {
                fruit.SetActive(true);
                fruit.transform.position += new Vector3(0, 2, 0);
                fruit.GetComponent<NetPlayerMovement>().Create();
            }
            else
            {
                fruit.SetActive(false);
            }
        }
    }

    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.Alpha1))
    //    {
    //        SetFruit("blocky");
    //    }

    //    if (Input.GetKeyDown(KeyCode.Alpha2))
    //    {
    //        SetFruit("wonky");
    //    }

    //    if (Input.GetKeyDown(KeyCode.Alpha3))
    //    {
    //        SetFruit("banana");
    //    }
    //}
}
