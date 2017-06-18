using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class molHit : MonoBehaviour {
	public Text scoreText;
	int score = 0;

	public void hit(int moleNumber){
		score += 1000;
		scoreText.text = score.ToString ();
	}
}
