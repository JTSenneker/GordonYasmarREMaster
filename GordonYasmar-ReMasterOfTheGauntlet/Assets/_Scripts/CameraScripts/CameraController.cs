using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    public Transform camTarget;
    public Vector3 posOffset;
    public float xRot = 50.5f;
    public float rotSpeed = 75.0f;
    private float yRot = 0.0f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void LateUpdate () {
        yRot += Input.GetAxis("CameraRotation") * rotSpeed * Time.deltaTime;
        Quaternion rotation = Quaternion.Euler(xRot, yRot, 0);
        Vector3 position = rotation * posOffset + camTarget.position;

        transform.rotation = rotation;
        transform.position = position;
	}
}
