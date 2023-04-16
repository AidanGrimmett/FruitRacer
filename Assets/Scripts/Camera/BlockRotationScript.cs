using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockRotationScript : MonoBehaviour
{


    private void FixedUpdate()
    {
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
    }
}
