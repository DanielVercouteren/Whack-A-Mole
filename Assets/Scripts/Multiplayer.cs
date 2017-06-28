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

	public int maxMoles = 72;	//totale amount of moles spread over the field if all are active, in mp its 36 per field.
	public float waitingtime = 1.3f;

	public GameObject hoofdmenu;

	public Text scoreTextLeft;
	public Text scoreTextRight;

	int scoreLeft = 0;  //LINKS SCORE
	int scoreRight = 0;  //RECHTS SCORE

	void Start(){
		mb.amountOfMoles = 72;
		Moles = new List<GameObject> ();  //put the moles in a list

		Moles = mb.findMoles (); 	//Get all moles, sorted

		
		foreach(GameObject mole in Moles){
			mole.SetActive (false);  //Set all moles invisible
		}

		//Start popping up moles, every waitingtime seconds
		//First mole will pop up after 5 seconds
		InvokeRepeating ("moleShow", 6.0f, waitingtime);
	}

	void moleShow(){
		randomMole = Random.Range (1, mb.amountOfMoles / 2); //get a random number between 1 and 36

		mb.popupMole (randomMole - 1); //pop up that mole in the list, left side(-1)
 		mb.popupMole (randomMole + 35); //pop up that mole in the list, right side(+35)
	}

	public void hit(int molNummer){  // on hit function, 
		if (!gameDone) {			 // check if the time is over
			mb.hideMole (molNummer - 1); //Hide mole hit

			//Check which side was the hit
			if (molNummer < 37) {  //if left side hit
				this.scoreLeft += 10; //score + 10
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
	
				mb.hideMole (molNummer + 35);  //Hide same mole rightside
				
			} else {						//if hit was right side	
				this.scoreRight += 10; //score + 10
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
				mb.hideMole (molNummer - 37); //Hide same mole leftside
			}
		}
	}

	public 	void showEndScore(Text left, Text right){
		gameDone = true; 
		hoofdmenu.SetActive (true); //homemenu button popup
		CancelInvoke ();
		StopAllCoroutines ();  //stop de coroutines van de game

		if (scoreLeft > scoreRight) { //check winnaar
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

		

	}

	public void returnHome(){
		SceneManager.LoadScene ("Initial"); //Koppel aan hoofdmenu knop
	}

	public void restartLevel(){
		SceneManager.LoadScene ("Multiplayer"); //Koppel aan herstart knop
	}
}
