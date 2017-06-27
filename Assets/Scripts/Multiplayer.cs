using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Multiplayer : MonoBehaviour {
	moleBehaviour mb = new moleBehaviour();

	List<GameObject> Moles;

	int randomMole;

	bool gameDone = false;

	public int maxMoles = 72;
	public float waitingtime = 1.3f;

	public GameObject hoofdmenu;

	public Text scoreTextLeft;
	public Text scoreTextRight;

	int scoreLeft = 0;  //LINKS SCORE
	int scoreRight = 0;  //RECHTS SCORE

	void Start(){
		mb.amountOfMoles = 72;
		Moles = new List<GameObject> ();

		//Get all moles, sorted
		Moles = mb.findMoles ();

		//Set all moles invisible + 
		foreach (GameObject mole in Moles) {
			mole.SetActive (false);
		}

		//Start popping up moles, every waitingtime seconds
		//First mole will pop up after 5 seconds
		InvokeRepeating ("moleShow", 6.0f, waitingtime);
	}

	void moleShow(){
		randomMole = Random.Range (1, mb.amountOfMoles / 2);

		mb.popupMole (randomMole - 1);
		mb.popupMole (randomMole + 35);
	}

	public void hit(int molNummer){
		if (!gameDone) {
			//Hide mole hit
			mb.hideMole (molNummer - 1);

			//Check which side
			if (molNummer < 37) {
				this.scoreLeft += 10;
				if (scoreLeft < 10) {
					scoreTextLeft.text = "Score: 0000" + scoreLeft.ToString ();
				} else if (scoreLeft < 100) {
					scoreTextLeft.text = "Score: 000" + scoreLeft.ToString ();
				} else if (scoreLeft < 1000) {
					scoreTextLeft.text = "Score: 00" + scoreLeft.ToString ();
				} else if (scoreLeft < 10000) {
					scoreTextLeft.text = "Score: 0" + scoreLeft.ToString ();
				} else {
					scoreTextLeft.text = "Score: " + scoreLeft.ToString ();
				} 
				//Hide same mole right
				mb.hideMole (molNummer + 35);
			} else {
				this.scoreRight += 10;
				if (scoreRight < 10) {
					scoreTextRight.text = "Score: 0000" + scoreRight.ToString ();
				} else if (scoreRight < 100) {
					scoreTextRight.text = "Score: 000" + scoreRight.ToString ();
				} else if (scoreRight < 1000) {
					scoreTextRight.text = "Score: 00" + scoreRight.ToString ();
				} else if (scoreRight < 10000) {
					scoreTextRight.text = "Score: 0" + scoreRight.ToString ();
				} else {
					scoreTextRight.text = "Score: " + scoreRight.ToString ();
				} 
				//Hide same mole left
				mb.hideMole (molNummer - 37);
			}
		}
	}

	public 	void showEndScore(Text left, Text right){
		gameDone = true;
		hoofdmenu.SetActive (true);
		CancelInvoke ();
		StopAllCoroutines ();

		if (scoreLeft > scoreRight) {
			left.text = "WINNAAR!";
			right.text = "LOSER!";
		} else if (scoreRight > scoreLeft) {
			left.text = "LOSER!";
			right.text = "WINNAAR!";
		} else {
			//Draw
			left.text = "GELIJKSPEL!";
			right.text = "GELIJKSPEL!";
		}

		//Show back button

	}

	public void returnHome(){
		SceneManager.LoadScene ("Initial");
	}

	public void restartLevel(){
		SceneManager.LoadScene ("Multiplayer");
	}
}
