using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class showMenu : MonoBehaviour {
	public GameObject gameMenu;

	public Text scoreText;
	Text hsText;

	public void hideMenu(){
		gameMenu = GameObject.FindGameObjectWithTag ("gameOverMenu");
		gameMenu.SetActive (false);
	}

	public void showMenuScreen(int score){
		scoreText.text = "Score: " + score;
		gameMenu.SetActive (true);
	}

	public void switchScreens(string screen){
		SceneManager.LoadScene (screen);
	}
}
