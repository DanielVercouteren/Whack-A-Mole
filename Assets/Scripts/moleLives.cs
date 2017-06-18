using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class moleLives : MonoBehaviour
{
	public int lives = 5;

	public Image heart1, heart2, heart3, heart4, heart5;

	public void loseALive(){
		this.lives -= 1;

		Debug.Log ("Lost a live! " + lives + " lives left..");
		switch (lives) {
		case 4:
			heart5.enabled = false;
			break;
		case 3:
			heart4.enabled = false;
			break;
		case 2:
			heart3.enabled = false;
			break;
		case 1:
			heart2.enabled = false;
			break;
		case 0:
			heart1.enabled = false;
			Debug.Log ("Game over!");
			break;
		}
	}
}

