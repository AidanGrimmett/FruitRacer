using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dropScript : MonoBehaviour
{
    public GameObject[] prefabs;

    private GameObject chosenPrefab;

    public GameObject GetChosenPrefab()
    {
        chosenPrefab = prefabs[this.gameObject.GetComponent<Dropdown>().value];
        return chosenPrefab;
    }
}
