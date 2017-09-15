using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienShip : MonoBehaviour {

    public float speed;
    public float direction;

    public int pointValue;
    public AudioClip deathSound;

    // Use this for initialization
    void Start () {
        speed = 10.0f;
        direction = 1.0f;
        pointValue = Random.Range(10, 100);
    }

    // Update is called once per frame
    void Update () {

        gameObject.transform.Translate(Vector3.right * direction * speed * Time.deltaTime);

        Vector3 objPos = gameObject.transform.position;

        if (objPos.x >= 145 || objPos.x <= -145)
        {
            Destroy(gameObject);
        }
    }


    public void Die()
    {
        AudioSource.PlayClipAtPoint(deathSound, gameObject.transform.position);

        GameObject globalObj = GameObject.Find("GlobalObject");
        Global g = globalObj.GetComponent<Global>();
        g.score += pointValue;

        Destroy(gameObject);
    }
}
