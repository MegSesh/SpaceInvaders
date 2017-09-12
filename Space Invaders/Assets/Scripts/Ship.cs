using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Ship : MonoBehaviour {

    public float speed;
    public GameObject shipMissile;

    public int lives;
    public GameObject alienArmy;
    public Vector3 alienArmyStartPos;

    //NOT SURE why GUIText didn't work
    //http://answers.unity3d.com/questions/847329/cannot-assign-guitext-to-script.html
    //public GUIText livesGUI;
    public Text livesGUI;

	// Use this for initialization
	void Start () {
        speed = 20.0f;
        lives = 3;

        alienArmy = GameObject.Find("AlienArmy");
        alienArmyStartPos = alienArmy.transform.position;

        livesGUI.text = "Lives: " + lives.ToString();
	}//end Start function
	
	// Update is called once per frame
	void Update () {

        Vector3 objPos = gameObject.transform.position;

        if (Input.GetKey("right") && objPos.x < 120.0)
        {
            gameObject.transform.Translate(Vector3.right * speed * Time.deltaTime);
        }

        if (Input.GetKey("left") && objPos.x > -120.0)
        {
            gameObject.transform.Translate(Vector3.left * speed * Time.deltaTime);
        }

        if(Input.GetKeyDown("space"))   //GetKeyDown makes sure to spawn only once per press, vs constantly with GetKey
        {
            GameObject missileToSpawn = Instantiate(shipMissile, objPos, Quaternion.identity) as GameObject;
        }

    }//end Update function

    /*
     * Reset screen and subtract a life once player is hit.
     */
    void Attacked()
    {
        if(lives == 0)
        {
            SceneManager.LoadScene("LevelEnd");
        }
        else
        {
            lives--;
            livesGUI.text = "Lives: " + lives.ToString();

            alienArmy.transform.position = alienArmyStartPos;
            AlienArmy alienArmyScript = alienArmy.GetComponent<AlienArmy>();
            alienArmyScript.direction = 0.0f;

            StartCoroutine(Wait(2));

            alienArmyScript.direction = 1.0f;
        }


    }

    IEnumerator Wait(int secToWait)
    {
        yield return new WaitForSeconds(secToWait);
    }//end 
}
