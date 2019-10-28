using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour {
    public Text ScoreText; //宣告一個ScoreText的text
	// Use this for initialization
	void Start () {
        ScoreText.text = "Last game score :-" + BossBehavior.score;

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
