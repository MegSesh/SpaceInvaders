using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienShip : MonoBehaviour {

    public float speed;
    public float direction;

    public int pointValue;
    public AudioClip deathSound;

    public GameObject deathExplosion;

    // Use this for initialization
    void Start () {
        speed = Random.Range(20.0f, 40.0f);
        direction = 1.0f;
        pointValue = Random.Range(10, 100);
    }

    // Update is called once per frame
    void Update () {

        gameObject.transform.Translate(Vector3.right * direction * speed * Time.deltaTime);

        Vector3 objPos = gameObject.transform.position;

        //Destroy alien ship if it goes outside screen coordinates in x and y
        if (objPos.x >= 145 || objPos.x <= -145 || objPos.y <= -85 || objPos.y >= 105)
        {
            Destroy(gameObject);
        }
    }


    public void Die()
    {
        AudioSource.PlayClipAtPoint(deathSound, gameObject.transform.position);

        GameObject explosion = Instantiate(deathExplosion, gameObject.transform.position, Quaternion.identity) as GameObject;

        Destroy(gameObject);
    }
}
