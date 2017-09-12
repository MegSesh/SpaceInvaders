using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMissile : MonoBehaviour {

	// Use this for initialization
	void Start () {

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
            //Implement a Die() function in Alien10/20/30 script
            //Alien10 alien10 = collider.gameObject.GetComponent<Alien10>();
            //alien10.Die();
            Destroy(collider.gameObject);

            //Destroy myself
            Destroy(gameObject);
        }

        else if (collider.CompareTag("Base"))
        {
            Destroy(collider.gameObject);
            Destroy(gameObject);
        }
    }
}
