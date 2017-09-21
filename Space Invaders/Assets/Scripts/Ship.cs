using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Ship : MonoBehaviour {

    public float speed;
    public GameObject shipMissile;
    public GameObject alienArmy;
    public Vector3 alienArmyStartPos;

    //NOT SURE why GUIText didn't work
    //http://answers.unity3d.com/questions/847329/cannot-assign-guitext-to-script.html
    //public GUIText livesGUI;
    public Text livesGUI;
    public int lives;

    public int ammo;
    public Text ammoGUI;
    public AudioClip deathSound;
    public GameObject deathExplosion;
    GameObject cameraShake;
    private float offsetFactor;
    private float degOffset;

	// Use this for initialization
	void Start () {
        speed = 20.0f;
        lives = 3;
        ammo = 60;
        alienArmy = GameObject.Find("AlienArmy");
        alienArmyStartPos = alienArmy.transform.position;
        livesGUI.text = "Lives: " + lives.ToString();
        ammoGUI.text = "Ammo: " + ammo.ToString();
        cameraShake = GameObject.Find("Main Camera");
        offsetFactor = 8.0f;
        degOffset = 0.0f;
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

        //GetKeyDown makes sure to spawn only once per press, vs constantly with GetKey
        if (Input.GetKeyDown("space"))   
        {
            Vector3 dir = new Vector3(0.0f, 1.0f, 0.0f);
            Vector3 posOffset = dir.normalized * offsetFactor;
            Quaternion spawnDirQuat = Quaternion.Euler(0.0f, 0.0f, degOffset);
            GameObject missileToSpawn = Instantiate(shipMissile, objPos + posOffset, spawnDirQuat) as GameObject;
            ammo--;
        }

        if (Input.GetKey("up"))
        {
            degOffset += 5.0f;
        }

        if (Input.GetKey("down"))
        {
            degOffset -= 5.0f;
        }

        //Want to instantiate bullets for mouse click
        //https://docs.unity3d.com/ScriptReference/Input-mousePosition.html
        //Convert Vector2 mouse pos to angle --> http://answers.unity3d.com/questions/189870/convert-vector2-mouse-position-into-angle.html
        if (Input.GetMouseButtonDown(0))// && Input.mousePosition.y > -85)  //take care of exit button
        {
            Vector3 mousePos = Input.mousePosition;
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(mousePos);
            mouseWorldPos.z = 10.0f;

            Vector3 spawnDirection = mouseWorldPos - objPos;

            //Convert the x and y of spawnDirection into an angle to feed into z
            float angleRadians = Mathf.Atan2(spawnDirection.y, spawnDirection.x);
            float angleDeg = angleRadians * Mathf.Rad2Deg;
            Quaternion spawnDirQuat = Quaternion.Euler(0.0f, 0.0f, angleDeg - 90.0f);

            Vector3 posOffset = spawnDirection.normalized * offsetFactor;

            GameObject missileToSpawn = Instantiate(shipMissile, objPos + posOffset, spawnDirQuat) as GameObject;
            ammo--;
        }

        ammoGUI.text = "Ammo: " + ammo.ToString();

    }//end Update function

    /*
     * Reset screen and subtract a life once player is hit.
     */
    void Attacked()
    {
        if(lives == 0 || ammo <= 0)
        {
            SceneManager.LoadScene("TitleScreen");
        }
        else
        {
            AudioSource.PlayClipAtPoint(deathSound, gameObject.transform.position);

            GameObject explosion = Instantiate(deathExplosion, gameObject.transform.position, Quaternion.identity) as GameObject;

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


    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("AlienShip"))
        {
            Attacked();
            Destroy(collider.gameObject);
        }
    }
}
