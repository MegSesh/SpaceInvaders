using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScript : MonoBehaviour {

    public Text scoreText;

	// Use this for initialization
	void Start () {
        //this only works if you have a globalobject gameobject in your scene
        //GameObject globalObj = GameObject.Find("GlobalObject");
        //Global g = globalObj.GetComponent<Global>();
        //scoreText.text = "Score: " + g.score.ToString();		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnGUI()
    {
        GUILayout.BeginArea(new Rect(10, Screen.height / 2 + 50, Screen.width - 20, 100));

        if (GUILayout.Button("Play again"))
        {
            SceneManager.LoadScene("TitleScreen");
        }

        if (GUILayout.Button("Exit"))
        {
            Application.Quit();

            Debug.Log("Application.Quit() only works in build, not in editor");
        }

        GUILayout.EndArea();
    }
}
