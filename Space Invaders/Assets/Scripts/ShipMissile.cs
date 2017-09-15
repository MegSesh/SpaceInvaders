using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipMissile : MonoBehaviour {

    //public int score;
    //public Text scoreGUI;

    // Use this for initialization
    void Start () {

        //score = 0;
        //scoreGUI.text = "Score: " + score.ToString();

        StartCoroutine(destroyMissile());

    }//end Start function

    // Update is called once per frame
    void Update () {

        gameObject.transform.Translate(Vector3.up * 50.0f * Time.deltaTime);

	}//end Update function

    /*
     * How to destroy the missile after 5 seconds
     * http://answers.unity3d.com/questions/350721/c-yield-waitforseconds.html
     */
    IEnumerator destroyMissile()
    {
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }//end destroyMissile function

    /*
     * Since we have "Is Trigger" selected in 
     * ShipMissile prefab's Capsule Collider component
     * we can't use OnCollisionEnter.
     * Must use OnTriggerEnter
     */ 
     void OnTriggerEnter(Collider collider)
    {
        if(collider.CompareTag("Enemy"))
        {
            //score += Random.Range(10, 100);

            //Implement a Die() function in Alien10/20/30 script
            //Alien10 alien10 = collider.gameObject.GetComponent<Alien10>();
            //alien10.Die();
            Destroy(collider.gameObject);

            //Destroy myself
            Destroy(gameObject);
        }

        if(collider.CompareTag("Alien10"))
        {
            //Destroy alien 10
            Alien10 alien_10 = collider.gameObject.GetComponent<Alien10>();
            alien_10.Die();

            //Destroy myself
            Destroy(gameObject);
        }

        else if (collider.CompareTag("Alien20"))
        {
            //Destroy alien 20
            Alien20 alien_20 = collider.gameObject.GetComponent<Alien20>();
            alien_20.Die();

            //Destroy myself
            Destroy(gameObject);
        }

        else if (collider.CompareTag("Alien30"))
        {
            //Destroy alien 30
            Alien30 alien_30 = collider.gameObject.GetComponent<Alien30>();
            alien_30.Die();

            //Destroy myself
            Destroy(gameObject);
        }

        else if (collider.CompareTag("AlienShip"))
        {
            //Destroy alien 30
            AlienShip alien_ship = collider.gameObject.GetComponent<AlienShip>();
            alien_ship.Die();

            //Destroy myself
            Destroy(gameObject);
        }



        else if (collider.CompareTag("Base"))
        {
            Destroy(collider.gameObject);
            Destroy(gameObject);
        }

        //scoreGUI.text = "Score: " + score.ToString();

    }
}
