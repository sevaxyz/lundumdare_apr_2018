using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreGetter : MonoBehaviour {

    Text scoreText;

    // Use this for initialization
    void Awake () {
        var objList = GameObject.FindGameObjectsWithTag("TotalScore");
        foreach (var obj in objList)
        {
            scoreText = obj.GetComponent<Text>();
        }
        scoreText.text = "YOUR SCORE: " + Round.Instance().Score;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
