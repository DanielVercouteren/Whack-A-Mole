using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class moleLives : MonoBehaviour
{
	public int lives = 5;

	GameObject heart1, heart2, heart3, heart4, heart5;

	public void loseALive(){
		this.lives -= 1;

		Debug.Log ("Lost a live! " + lives + " lives left..");

		if (lives == 4) {
			heart5 = GameObject.FindGameObjectWithTag ("heart5");
			heart5.SetActive (false);
		} else if (lives == 3) {
			heart4 = GameObject.FindGameObjectWithTag ("heart4");
			heart4.SetActive (false);
		} else if (lives == 2) {
			heart3 = GameObject.FindGameObjectWithTag ("heart3");
			heart3.SetActive (false);
		} else if (lives == 1) {
			heart2 = GameObject.FindGameObjectWithTag ("heart2");
			heart2.SetActive (false);
		} else if (lives == 0) {
			heart1 = GameObject.FindGameObjectWithTag ("heart1");
			heart1.SetActive (false);
			Debug.Log ("Game over!");
		}
	}
}

