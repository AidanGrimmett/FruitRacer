using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockRotationScript : MonoBehaviour
{
    //private Vector3 offset;
    //private void Start()
    //{
    //    offset = transform.localPosition;
    //    Debug.Log(offset);
    //}
    private void Update()
    {
        transform.position = transform.parent.transform.position;
    }
}
