using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnGUI()
    {
        GUILayout.BeginArea(new Rect(10, Screen.height / 2 + 50, Screen.width - 20, 100));

        if (GUILayout.Button("New Game"))
        {
            SceneManager.LoadScene("SI_Scene_1");
        }

        if (GUILayout.Button("High score"))
        {
            Debug.Log("You should implement a high score screen.");
        }

        if (GUILayout.Button("Exit"))
        {
            Application.Quit();

            Debug.Log("Application.Quit() only works in build, not in editor");
        }

        GUILayout.EndArea();
    }
}
