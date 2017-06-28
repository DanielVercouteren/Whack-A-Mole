using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class startGame : MonoBehaviour {
	public int players;
	public int seconds;

	public void setTime(int seconds){ //in the initial screen, check the amount of seconds to play in multiplayer
		PlayerPrefs.SetInt ("Time", seconds); 
		PlayerPrefs.Save ();
	}

	public void switchCanvas(int players){ //canvas out of the initial scene, singleplayer or multiplayer
		PlayerPrefs.SetInt ("Players", players);
		PlayerPrefs.Save ();

		if (players == 1) {
			SceneManager.LoadScene ("Singleplayer");
		} else if (players == 2) {
			SceneManager.LoadScene ("Multiplayer");
		}
	}
}
