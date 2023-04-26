using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boing : MonoBehaviour
{
    public float intensity;

    //Dictionary<string, float> bouncers = new Dictionary<string, float>() {
    //    { "regular", 80.0f },
    //    { "mega", 150.0f },
    //    { "galactic", 300.0f },
    //};

    //public string bounceType;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("BOINGGG");
            other.GetComponent<NewPlayerMovement>().Fly(intensity);
        }
    }
}
