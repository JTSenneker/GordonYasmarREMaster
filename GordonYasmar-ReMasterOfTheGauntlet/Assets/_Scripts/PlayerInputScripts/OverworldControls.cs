using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class OverworldControls : MonoBehaviour {



    public float speed = 5;
    public float grav = -1;

    private float inputH;
    private float inputV;
    private float yRotation;

    private CharacterController charController;
    // Use this for initialization
    void Start() {
        charController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update() {
        inputH = Input.GetAxis("Horizontal");
        inputV = Input.GetAxis("Vertical");

        if (inputH != 0 || inputV != 0) {
            RotateY();
        }
        
        Vector3 movement = new Vector3(inputH, 0, inputV);
        if(movement.magnitude > 1) {
            movement.Normalize();
        }

        Vector3 gravity = new Vector3(0, grav, 0);
        if (charController.isGrounded) gravity.y = 0;
        else gravity.y = grav;

        charController.Move(gravity + (transform.forward*movement.magnitude*speed*Time.deltaTime));
	}

    void RotateY() {
        yRotation = Mathf.Atan2(inputH, inputV)*Mathf.Rad2Deg + Camera.main.transform.rotation.eulerAngles.y;
        Quaternion rotation = Quaternion.Euler(new Vector3(0, yRotation, 0));
        transform.rotation = rotation;
    }
}
