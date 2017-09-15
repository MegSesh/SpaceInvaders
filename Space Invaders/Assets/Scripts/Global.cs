using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Global : MonoBehaviour {

    public int score;

    public GameObject alienShip;
    float counter;
    public float alienShipLaunchTime;



    // Use this for initialization
    void Start () {
        LaunchReset();
        score = 0;
	}//end Start function
	
	// Update is called once per frame
	void Update () {

        //Where I want to spawn alien ship from 
        Vector3 objPos = new Vector3(-135.0f, 86.0f, 10.0f);

        counter += Time.deltaTime;
        if(counter > alienShipLaunchTime)
        {
            GameObject missileToSpawn = Instantiate(alienShip, objPos, Quaternion.identity) as GameObject;
            LaunchReset();
        }
    }//end Update function

    void LaunchReset()
    {
        counter = 0.0f;
        alienShipLaunchTime = Random.Range(10.0f, 20.0f);
    }//end Reset function
}
