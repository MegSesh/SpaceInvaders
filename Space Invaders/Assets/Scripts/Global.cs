using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Global : MonoBehaviour {

    public int score;

    public GameObject alienShip;
    float counter;
    public float alienShipLaunchTime;
    public GameObject ship;
    Vector3 shipPos;



    // Use this for initialization
    void Start () {
        LaunchReset();
        score = 0;
        ship = GameObject.Find("Ship");
        //shipPos = ship.transform.position;

	}//end Start function
	
	// Update is called once per frame
	void Update () {

        //Where I want to spawn alien ship from 
        //Vector3 objPos = new Vector3(-135.0f, 86.0f, 10.0f);

        counter += Time.deltaTime;
        if(counter > alienShipLaunchTime)
        {
            shipPos = ship.transform.position;

            int spawnTime = Random.Range(0, 100);

            Vector3 spawnPos;
            Quaternion spawnDir;

            if(spawnTime < 50)
            {
                float rand_x = Random.Range(-135.0f, 135.0f);
                float rand_y = Random.Range(-85.0f, 100.0f);
                float _z = 10.0f;
                spawnPos = new Vector3(rand_x, rand_y, _z);

                Vector3 dirFromShipToAlien = shipPos - spawnPos;
                float angleRadians = Mathf.Atan2(dirFromShipToAlien.y, dirFromShipToAlien.x);
                float angleDeg = angleRadians * Mathf.Rad2Deg;
                spawnDir = Quaternion.Euler(0.0f, 0.0f, angleDeg);
            }
            else
            {
                spawnPos = new Vector3(-135.0f, 86.0f, 10.0f);
                spawnDir = Quaternion.identity;
            }

            GameObject missileToSpawn = Instantiate(alienShip, spawnPos, spawnDir) as GameObject;
            LaunchReset();
        }
    }//end Update function

    void LaunchReset()
    {
        counter = 0.0f;
        alienShipLaunchTime = Random.Range(10.0f, 20.0f);
    }//end Reset function
}
