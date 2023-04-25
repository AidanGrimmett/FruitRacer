using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraScript : MonoBehaviour
{
    //way to change the camera position
    public void ChangeOffset(Vector3 offset)
    {
        this.transform.position = offset;
    }
}
