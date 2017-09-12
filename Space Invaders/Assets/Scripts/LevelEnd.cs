using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEnd : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    /*
     * SceneManager --> https://forum.unity3d.com/threads/unityengine-application-loadlevel-int-is-obsolete.372915/
     */
    void OnTriggerEnter(Collider collider)
    {
        if(collider.CompareTag("Enemy"))
        {
            //Application.LoadLevel("LevelEnd");        //Deprecated. Use SceneManager
            SceneManager.LoadScene("LevelEnd");
            
        }
    }
}
