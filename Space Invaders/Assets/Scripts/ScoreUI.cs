using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour {

    //GUIText scoreText;
    //Text scoreText;
    public Text scoreText;

    Global globalObj;

    // Use this for initialization
    void Start () {
        GameObject g = GameObject.Find("GlobalObject");
        globalObj = g.GetComponent<Global>();

        //scoreText = gameObject.GetComponent<GUIText>();
        //scoreText = gameObject.GetComponent<Text>();
        scoreText.text = "Score: " + globalObj.score.ToString();
    }
	
	// Update is called once per frame
	void Update () {
        //scoreText.text = "Score: " + globalObj.score.ToString();
        scoreText.text = "Score: " + globalObj.score.ToString();
    }
}
