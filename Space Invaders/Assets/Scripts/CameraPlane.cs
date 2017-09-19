using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPlane : MonoBehaviour {

    public GameObject cameraToFollow;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        Vector3 cameraPos = cameraToFollow.transform.position;

        Vector3 planePos = new Vector3(cameraPos.x + 25.0f, cameraPos.y + 45.0f, cameraPos.z + 40.0f);


        Quaternion planeRot = Quaternion.Euler(15.0f, 0.0f, 180.0f);


        gameObject.transform.position = planePos;
        gameObject.transform.rotation = planeRot;
    }
}
