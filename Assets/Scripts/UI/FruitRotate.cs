using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitRotate : MonoBehaviour
{
    public float speed = 50.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f, 1.0f * Time.deltaTime * speed, 0f, Space.World);
    }
}
