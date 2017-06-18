using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class showMole : MonoBehaviour {
	moleBehaviour mb = new moleBehaviour();
	moleLives ml = new moleLives ();
	List<GameObject> Moles;
	List<int> ActiveMoles;

	int randomMole;

	public int maxMoles = 7;
	public float waitingtime = 4.0f;

	public Text scoreText;
	int score = 0;

	void Start(){
		Moles = new List<GameObject>();
		ActiveMoles = new List<int> ();

		//Get all moles, sorted
		Moles = mb.findMoles ();

		//Set all moles invisible + 
		foreach (GameObject mole in Moles) {
			mole.SetActive (false);
		}
			
		//Start popping up moles, every waitingtime seconds;
		InvokeRepeating ("moleAnimation", 7.0f, waitingtime);
	}

	void moleAnimation(){
		//Check how many moles are on the screen
		//if maxMoles is not reached, go in
		if (ActiveMoles.Count < maxMoles) {
			//Pop up a random mole in range 0 - amount of moles
			randomMole = Random.Range(1, mb.amountOfMoles);

			//Check if mole already exists.
			while (ActiveMoles.Contains (randomMole)) {
				randomMole = Random.Range(1, mb.amountOfMoles);
			}

			//Add the mole number to ActiveMoles
			ActiveMoles.Add (randomMole );

			//Popup the mole from MoleList[randomMole - 1]
			mb.popupMole (randomMole - 1);
		} else {
			//Hide longest waiting mol
			mb.hideMole (ActiveMoles[0]);
			ActiveMoles.RemoveAt(ActiveMoles[0]);

			Debug.Log ("Lost a live!");
			ml.loseALive ();
			if (ml.lives == 0) {
				//Stop the game

			} else {
				//Repeat process
				moleAnimation ();
			}
			
		}
	}

	public void hit(int molNummer){
		this.score += 1;
		if (score < 10) {
			scoreText.text = "0000" + score.ToString ();
		} else if (score < 100) {
			scoreText.text = "000" + score.ToString ();
		} else if (score < 1000) {
			scoreText.text = "00" + score.ToString ();
		} else if (score < 10000) {
			scoreText.text = "0" + score.ToString ();
		} else {
			scoreText.text = score.ToString ();
		}

		Debug.Log ("Hide mole " + molNummer + " at index: " + ActiveMoles.IndexOf (molNummer));
		mb.hideMole (molNummer - 1);
		ActiveMoles.RemoveAt(ActiveMoles.IndexOf (molNummer));
	}
}
