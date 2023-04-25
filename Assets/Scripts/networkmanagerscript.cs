using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using UnityEngine.UI;
using TMPro;

public class networkmanagerscript : MonoBehaviour
{
    public GameObject banana;
    public GameObject blocky;
    public GameObject wonky;

    private GameObject fruit;

    public GameObject fruittext;

    private NetworkVariable<GameObject> fruitObj = new NetworkVariable<GameObject>(null, NetworkVariableReadPermission.Everyone, NetworkVariableWritePermission.Owner);

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            fruitObj.Value = blocky;
            SetFruit(fruitObj.Value);
            Debug.Log("Select blocky");
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            fruitObj.Value = wonky;
            SetFruit(fruitObj.Value);
            Debug.Log("Select wonky");
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            fruitObj.Value = banana;
            SetFruit(fruitObj.Value);
            Debug.Log("Select banana");
        }
    }

    private void SetFruit(GameObject newFruit)
    {
        fruit = newFruit;
        Debug.Log("Setting fruit to " + newFruit.name);
        fruittext.GetComponent<TextMeshProUGUI>().SetText("");
        fruittext.GetComponent<TextMeshProUGUI>().SetText(newFruit.name);

        GetComponent<NetworkManager>().NetworkConfig.PlayerPrefab = fruit;
    }
}
