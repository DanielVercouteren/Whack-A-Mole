using UnityEngine;
using System.Collections;

public class startGame : MonoBehaviour {
	public int players;

	public void switchCanvas(int players){
		Application.LoadLevel (players);
	}
		
}
