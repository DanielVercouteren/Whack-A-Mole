using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class countdownTimer : MonoBehaviour {
	public Text secondText;
	int seconds;
	int players;

	public Text rsgText1;
	public Text rsgText2;
	string text1 = "Ready?";
	string text2 = "Set?";
	string text3 = "Go!!";

	GUIStyle style = new GUIStyle ();

	// Use this for initialization
	void Start () {
		style.richText = true;

		//Get players from PlayerPrefs
		players = PlayerPrefs.GetInt ("Players");

		//Show RSG text according to amount of players
		if (players == 1) {
			StartCoroutine (countDownSinglePlayer ());
		}else if(players == 2) {
			seconds = PlayerPrefs.GetInt ("Time");
			secondText.text = "" + seconds;
			StartCoroutine (countDownMultiPlayer ());
		}
	}

	private IEnumerator countDownSinglePlayer(){
		//Wait for 1000ms. before counting down
		yield return new WaitForSeconds(1f);
		rsgText1.text = text1;
		//Show 1700ms.
		yield return new WaitForSeconds(1.7f);
		rsgText1.text = text2;
		//Show 1700ms.
		yield return new WaitForSeconds(1.7f);
		rsgText1.text = text3;
		//Show 600ms.
		yield return new WaitForSeconds(0.6f);
		rsgText1.enabled = false;
	}

	private IEnumerator countDownMultiPlayer(){
		//Wait for 1000ms. before counting down
		yield return new WaitForSeconds(1f);
		rsgText1.text = text1;
		rsgText2.text = text1;
		//Show 1700ms.
		yield return new WaitForSeconds(1.7f);
		rsgText1.text = text2;
		rsgText2.text = text2;
		//Show 1700ms.
		yield return new WaitForSeconds(1.7f);
		rsgText1.text = text3;
		rsgText2.text = text3;
		//Show 600ms.
		yield return new WaitForSeconds(0.6f);
		rsgText1.enabled = false;
		rsgText2.enabled = false;

		//Start counting down after last wait every 1.0f seconds
		InvokeRepeating ("count", 0.0f, 1.0f);
	}
		
	void count(){
		seconds = seconds - 1;
		secondText.text = "" + seconds;

		//Make the timer red in the last ten seconds
		if (seconds < 10) {
			secondText.color = Color.red;
		}

		if (seconds == 0) {
			rsgText1.enabled = true;
			rsgText2.enabled = true;

			rsgText1.text = "Tijd is op!";
			rsgText2.text = "Tijd is op!";
		}
	}
}