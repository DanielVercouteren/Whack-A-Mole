using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class startGame : MonoBehaviour {
	public int players;
	public int seconds;

	public void setTime(int seconds){
		PlayerPrefs.SetInt ("Time", seconds);
		PlayerPrefs.Save ();
	}

	public void switchCanvas(int players){
		PlayerPrefs.SetInt ("Players", players);
		PlayerPrefs.Save ();

		if (players == 1) {
			SceneManager.LoadScene ("Singleplayer");
		} else if (players == 2) {
			SceneManager.LoadScene ("Multiplayer");
		}
	}
}
