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

    public AudioClip deathSound;

    GameObject cameraShake;

	// Use this for initialization
	void Start () {
        speed = 20.0f;
        lives = 3;

        alienArmy = GameObject.Find("AlienArmy");
        alienArmyStartPos = alienArmy.transform.position;

        livesGUI.text = "Lives: " + lives.ToString();

        cameraShake = GameObject.Find("Main Camera");
	}//end Start function
	
	// Update is called once per frame
	void Update () {

        Vector3 objPos = gameObject.transform.position;
        Quaternion objRot = gameObject.transform.rotation;

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

        //Want to instantiate bullets for mouse click
        //https://docs.unity3d.com/ScriptReference/Input-mousePosition.html
        //Convert Vector2 mouse pos to angle --> http://answers.unity3d.com/questions/189870/convert-vector2-mouse-position-into-angle.html
        if (Input.GetMouseButtonDown(0))
        {

            //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 mousePos = Input.mousePosition;
            //mousePos.z = 10.0f;
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(mousePos);
            mouseWorldPos.z = 10.0f;

            //Debug.Log("mousePixelPos:" + mousePos);
            //Debug.Log("mouse world pos: " + mouseWorldPos);

            //if (Physics.Raycast(ray))
            //{

            Vector3 spawnDirection = mouseWorldPos - objPos;    //Input.mousePosition - objPos;      //NEED TO CONVERT MOUSE PIXEL POS TO WORLD POS FIRST

            //Debug.Log("obj pos: " + objPos);
            //Debug.Log("spawn direction: " + spawnDirection);

            //Convert the x and y of spawnDirection into an angle to feed into z
            float angleRadians = Mathf.Atan2(spawnDirection.y, spawnDirection.x);
            float angleDeg = angleRadians * Mathf.Rad2Deg;

            //Debug.Log("angle radians: " + angleRadians);
            //Debug.Log("degrees: " + angleDeg); 


            Quaternion spawnDirQuat = Quaternion.Euler(0.0f, 0.0f, angleDeg - 90.0f);
            //Quaternion spawnDirQuat = Quaternion.Euler(0.0f, 0.0f, 90.0f);

            float offsetFactor = 10.0f;
            Vector3 posOffset = spawnDirection.normalized * offsetFactor;

            GameObject missileToSpawn = Instantiate(shipMissile, objPos + posOffset, spawnDirQuat) as GameObject;
            //}
        }

    }//end Update function

    /*
     * Reset screen and subtract a life once player is hit.
     */
    void Attacked()
    {
        if(lives == 0)
        {
            SceneManager.LoadScene("TitleScreen");
        }
        else
        {
            AudioSource.PlayClipAtPoint(deathSound, gameObject.transform.position);

            CameraShake camShakeScript = cameraShake.GetComponent<CameraShake>();
            camShakeScript.ShakeCamera(20.0f, 1.0f);

            lives--;
            livesGUI.text = "Lives: " + lives.ToString();

            alienArmy.transform.position = alienArmyStartPos;
            AlienArmy alienArmyScript = alienArmy.GetComponent<AlienArmy>();
            alienArmyScript.direction = 0.0f;

            StartCoroutine(Wait(2));

            alienArmyScript.direction = 1.0f;
        }
    }//end Attacked function

    IEnumerator Wait(int secToWait)
    {
        yield return new WaitForSeconds(secToWait);
    }//end 
}
