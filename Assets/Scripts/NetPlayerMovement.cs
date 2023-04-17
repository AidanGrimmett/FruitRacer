using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class NetPlayerMovement : NetworkBehaviour
{
    private Camera mainCam;
    public float speed;
    public float dragMultiplyer;
    public float topSpeed;

    private Rigidbody rb;
    private void Start()
    {
        if (!IsOwner) return;
        
        //disable every single camera 
        if (IsLocalPlayer)
        {
            mainCam = GetComponentInChildren<Camera>();
            foreach (GameObject obj in FindObjectsOfType<GameObject>())
            {
                if (obj.GetComponent<Camera>())
                {
                    obj.SetActive(false);
                }
            }
            //re-enable our one
            mainCam.gameObject.SetActive(true);
        }
        //ez rigidbody reference
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (!IsOwner) return;

        //read inputs
        float xInput = Input.GetAxis("Vertical");
        float zInput = Input.GetAxis("Horizontal");

        //only do this stuff if there's actually been an input
        if (xInput != 0 || zInput != 0)
        {
            //limit the zoomz
            if (rb.velocity.magnitude < topSpeed)
            {
                //find the direction of the camera
                Vector3 camForward = mainCam.transform.forward;
                camForward.y = 0;

                //normalize
                camForward = camForward.normalized;

                //movement force Vector
                Vector3 moveForce = camForward * xInput + mainCam.transform.right * zInput;

                //add the movement force
                rb.AddForce(moveForce * speed);
            }
        }
        else //slow down the player
        {
            //just applying whatever the opposite of the current velocity is, multiplied by how much drag we want
            Vector3 currentVelocity = rb.velocity;
            rb.AddForce((-1 * currentVelocity) * dragMultiplyer);
        }
    }
}
