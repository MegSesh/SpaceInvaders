using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien20 : MonoBehaviour {

    public int pointValue;
    public AudioClip deathSound;
    public GameObject deathExplosion;

    // Use this for initialization
    void Start () {
        pointValue = 20;
    }

    // Update is called once per frame
    void Update () {
		
	}

    public void Die()
    {
        AudioSource.PlayClipAtPoint(deathSound, gameObject.transform.position);
        GameObject explosion = Instantiate(deathExplosion, gameObject.transform.position, Quaternion.identity) as GameObject;   //Quaternion.AngleAxis(-90, Vector3.right)

        GameObject globalObj = GameObject.Find("GlobalObject");
        Global g = globalObj.GetComponent<Global>();
        g.score += pointValue;

        Destroy(gameObject);
    }


    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("WholeBase"))
        {
            //Destroy base
            Destroy(collider.gameObject);
        }
    }
}
