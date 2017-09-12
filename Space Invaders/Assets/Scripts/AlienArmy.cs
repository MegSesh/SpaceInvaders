using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienArmy : MonoBehaviour {

    public float speed;
    public float direction;

	// Use this for initialization
	void Start () {
        speed = 10.0f;
        direction = 1.0f;
	}
	
	// Update is called once per frame
	void Update () {

        gameObject.transform.Translate(Vector3.right * direction * speed * Time.deltaTime);

        Vector3 objPos = gameObject.transform.position;

        if (objPos.x >= 48)
        {
            direction = -1.0f;
            
            //objPos.y -= 15.0f;

            Vector3 newPos = new Vector3(objPos.x, objPos.y - 8.0f, objPos.z);
            gameObject.transform.position = newPos;

            //gameObject.transform.Translate(newPos);
        }

        else if (objPos.x <= -48)
        {
            direction = 1.0f;

            //objPos.y -= 15.0f;

            Vector3 newPos = new Vector3(objPos.x, objPos.y - 8.0f, objPos.z);
            gameObject.transform.position = newPos;

            //gameObject.transform.Translate(newPos);
        }

    }
}
