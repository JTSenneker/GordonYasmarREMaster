using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class OverworldControls : MonoBehaviour {
   


    public float speed = 10;

    private float inputH;
    private float inputV;

    private CharacterController charController;
	// Use this for initialization
	void Start () {
        charController = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
        inputH = Input.GetAxis("Horizontal");
        inputV = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(inputH, 0, inputV) * speed * Time.deltaTime;
        charController.Move(movement);
	}
}
