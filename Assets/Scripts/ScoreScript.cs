using UnityEngine;
using UnityEngine.UI;
using System.Collections;
	
public class ScoreScript : MonoBehaviour {

	public int score;

	public Text text;

	void Update(){
		text.text = "Score : " + score;
	}

	public void addScore(){
		score += 100;
	}
}
