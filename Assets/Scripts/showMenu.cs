using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class showMenu : MonoBehaviour {
	public GameObject gameMenu;
	public GameObject textObject;

	public Text scoreText;
	Text hsText;

	public void hideMenu(){
		gameMenu = GameObject.FindGameObjectWithTag ("gameOverMenu"); //gameover menu
		gameMenu.SetActive (false);
	}

	public void showMenuScreen(int score, Text highscoreText){
		this.hsText = highscoreText;
		gameMenu.SetActive (true);
		checkHighScore (score);
	}

	public void checkHighScore(int curScore){
		//int highScore = PlayerPrefs.GetInt ("HighScore");
		int highScore = 0;
		scoreText.text = "Score: " + curScore;

		if (curScore > highScore) {
			PlayerPrefs.SetInt ("HighScore", curScore);
			PlayerPrefs.Save ();
			StartCoroutine (BlinkText ());
		}
	}

	public void switchScreens(string screen){
		SceneManager.LoadScene (screen);
	}

	public IEnumerator BlinkText(){
		//blink it forever. You can set a terminating condition depending upon your requirement
		while(true){
			//set the Text's text to blank
			hsText.text= "";
			//display blank text for 0.5 seconds
			yield return new WaitForSeconds(.5f);
			//display “I AM FLASHING TEXT” for the next 0.5 seconds
			hsText.text= "NIEUWE HIGHSCORE!";
			yield return new WaitForSeconds(1.0f);
		}
	}

}
