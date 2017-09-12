using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMissile : MonoBehaviour {

    // Use this for initialization
    void Start()
    {

        StartCoroutine(destroyMissile());
    }//end Start function

    // Update is called once per frame
    void Update()
    {

        gameObject.transform.Translate(Vector3.down * 50.0f * Time.deltaTime);

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
        if (collider.CompareTag("Player"))
        {
            //Implement a Die() function in Ship script
            //Ship ship = collider.gameObject.GetComponent<Ship>();
            //ship.Die();

            //Destroy(collider.gameObject);

            /*
             * If the object I hit doesn't have a Ship script or an "Attacked" function
             * I don't need to be notified of that
            */
            collider.SendMessage("Attacked", SendMessageOptions.DontRequireReceiver);

            //Destroy myself
            Destroy(gameObject);
        }

        else if(collider.CompareTag("Base"))
        {
            Destroy(collider.gameObject);
            Destroy(gameObject);
        }
    }
}
