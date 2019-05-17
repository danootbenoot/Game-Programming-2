using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour {

	public Text scoreText;
	public int score;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		scoreText.text = "" + score;	


		if (score >= 1200) {
			SceneManager.LoadScene ("Win");
		}
	}

	public void IncreaseScore (int amountToIncrease){
		score += amountToIncrease;
	}
}
