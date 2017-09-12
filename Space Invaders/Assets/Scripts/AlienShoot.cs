using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienShoot : MonoBehaviour {

    public float shootTime;
    public GameObject alienMissile;
    float counter;

    // Use this for initialization
    void Start () {
        Reset();
        
	}//end Start function
	
	// Update is called once per frame
	void Update () {

        Vector3 objPos = gameObject.transform.position;

        counter += Time.deltaTime;
        if(counter > shootTime)
        {
            GameObject alienMissileToSpawn = Instantiate(alienMissile, objPos, Quaternion.identity) as GameObject;
            Reset();
        }
	}//end Update function

    void Reset()
    {
        counter = 0.0f;
        shootTime = Random.Range(10.0f, 20.0f);
    }//end Reset function
}
