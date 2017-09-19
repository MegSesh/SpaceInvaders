using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipMissile : MonoBehaviour {

    float speed;

    // Use this for initialization
    void Start () {

        speed = 50.0f;
        StartCoroutine(destroyMissile());

    }//end Start function

    // Update is called once per frame
    void Update () {

        gameObject.transform.Translate(Vector3.up * speed * Time.deltaTime);

    }//end Update function

    /*
     * How to destroy the missile after 5 seconds
     * http://answers.unity3d.com/questions/350721/c-yield-waitforseconds.html
     */
    IEnumerator destroyMissile()
    {
        yield return new WaitForSeconds(10);
        Destroy(gameObject);
    }//end destroyMissile function

    /*
     * Since we have "Is Trigger" selected in ShipMissile prefab's 
     * Capsule Collider component we can't use OnCollisionEnter.
     * Must use OnTriggerEnter
     */ 
     void OnTriggerEnter(Collider collider)
    {
        if(collider.CompareTag("Enemy"))
        {
            //Destroy Enemy
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

            //Different scoring for alien ship
            GameObject globalObj = GameObject.Find("GlobalObject");
            Global g = globalObj.GetComponent<Global>();

            int pt = alien_ship.pointValue;
            g.score += 3 * pt;

            //Destroy myself
            Destroy(gameObject);
        }

        else if (collider.CompareTag("Base"))
        {
            //Destroy base
            Destroy(collider.gameObject);

            //Destroy myself
            Destroy(gameObject);
        }

        else if(collider.CompareTag("LeftBarrier") || collider.CompareTag("RightBarrier"))
        {
            Quaternion origin = gameObject.transform.rotation;
            origin = Quaternion.Inverse(origin);
            gameObject.transform.rotation = origin;
        }

        else if (collider.CompareTag("TopBarrier"))
        {
            //Quaternion rotateBy;

            //if (collider.CompareTag("TopBarrier"))
            //{
            //    rotateBy = Quaternion.AngleAxis(180, Vector3.down);
            //}
            //else
            //{
            //    rotateBy = Quaternion.AngleAxis(180, Vector3.up);
            //}

            //Quaternion origin = gameObject.transform.rotation;
            //Debug.Log("origin: " + origin);

            //rotateBy = Quaternion.Euler(0.0f, 180.0f, 0.0f);
            //rotateBy = Quaternion.Euler(-origin.eulerAngles);

            //origin = origin * rotateBy;
            //origin = rotateBy;
            //Debug.Log("new origin: " + origin);
            //gameObject.transform.rotation = origin;


            Vector3 normal = new Vector3(0.0f, -1.0f, 0.0f);
            transform.up = Vector3.Reflect(transform.up, normal);
        }

        else if(collider.CompareTag("BottomBarrier"))
        {
            Vector3 normal = new Vector3(0.0f, 1.0f, 0.0f);
            transform.up = Vector3.Reflect(transform.up, normal);
        }

        //Ship can get killed by its own missile too
        else if(collider.CompareTag("Player"))
        {
            //Destroy player
            collider.SendMessage("Attacked", SendMessageOptions.DontRequireReceiver);

            //Destroy myself
            Destroy(gameObject);
        }

    }//end OnTriggerEnter function
}
