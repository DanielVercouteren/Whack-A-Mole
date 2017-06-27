using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Multiplayer : MonoBehaviour {

	moleBehaviour mb = new moleBehaviour();
	moleLives ml = new moleLives ();
	countdownTimer cdt = new countdownTimer ();

	List<GameObject> Moles;
	List<int> ActiveMoles;

	int randomMole;


	public int maxMoles = 16;
	public float waitingtime = 1.3f;

	public Text rsgText;
	public Text scoreText;
	int scoreLeft = 0;  //LINKS SCORE
	int scoreRight = 0;  //RECHTS SCORE

	void Start(){
		Moles = new List<GameObject> ();
		ActiveMoles = new List<int> ();

		//Get all moles, sorted
		Moles = mb.findMoles ();

		//Set all moles invisible + 
		foreach (GameObject mole in Moles) {
			mole.SetActive (false);
		}

		//Start popping up moles, every waitingtime seconds
		//First mole will pop up after 5 seconds
		InvokeRepeating ("startMole", 6.0f, waitingtime);
	}

	void startMole(){
		StartCoroutine (moleShow ());
	}

	IEnumerator moleShow(){
		int amountOfMolesToPop = Random.Range (2, 8);
		Debug.Log ("Will show " + amountOfMolesToPop + " moles!");

		for(int i = 0; i < amountOfMolesToPop; i++){
			yield return new WaitForSeconds (0.3f);
			Debug.Log ("Mole " + (i+1));
			//Check how many moles are on the screen
			//if maxMoles is not reached, go in
			if (ActiveMoles.Count < maxMoles) {
				//Pop up a random mole in range 1 - amount of moles ("Mol 1" - "Mol 32")
				randomMole = Random.Range (1, mb.amountOfMoles);

				//Check if mole already exists.
				//If it exists, activate a new mole
				while (ActiveMoles.Contains (randomMole)) {
					randomMole = Random.Range (1, mb.amountOfMoles);
				}

				Debug.Log ("Mole #" + (i+1) + " is mole " + randomMole);

				//Add the mole number to ActiveMoles
				ActiveMoles.Add (randomMole);

				//Popup the mole from MoleList[randomMole - 1]
				mb.popupMole (randomMole - 1);
			} else {
				moleHide ();
			}
		}

		//Randomly hide the last mole (10% chance)
		int randomHideInt = Random.Range (0, 10);
		Debug.Log ("Random int: " + randomHideInt);
		if (randomHideInt == 1) {
			Debug.Log ("Let's hide a random mole");
			StartCoroutine(randomHide());
		}
	}

	IEnumerator randomHide(){
		//Check what mole is first to hide
		int firstMole = ActiveMoles[0];
		Debug.Log ("Will hide mole " + ActiveMoles [0]);
		//Wait for 1,2s
		yield return new WaitForSeconds (1.2f);

		//Check what mole is first to hide (again, to check.)
		//If it's still the same mole, hide it.
		if (firstMole == ActiveMoles[0]) {
			moleHide ();
		}
	}

	void moleHide(){
		//Hide longest waiting mole
		//Remove the mole from the ActiveMoles list.
		Debug.Log ("Hiding mole " + ActiveMoles [0]);
		mb.hideMole (ActiveMoles [0] - 1);
		ActiveMoles.RemoveAt (0);

		}



public void hit(int molNummer){

		if (side == 0) {
		this.scoreLeft += 10;
		if (scoreLeft < 10) {
			scoreText.text = "0000" + scoreLeft.ToString ();
		} else if (scoreLeft < 100) {
			scoreText.text = "000" + scoreLeft.ToString ();
		} else if (scoreLeft < 1000) {
			scoreText.text = "00" + scoreLeft.ToString ();
		} else if (scoreLeft < 10000) {
			scoreText.text = "0" + scoreLeft.ToString ();
		} else {
			scoreText.text = scoreLeft.ToString ();
		} 
		mb.hideMole (molNummer - 1);
		ActiveMoles.RemoveAt(ActiveMoles.IndexOf (molNummer));
	}
	else {
		this.scoreLeft += 10;
		if (scoreLeft < 10) {
			scoreText.text = "0000" + scoreLeft.ToString ();
		} else if (scoreLeft < 100) {
			scoreText.text = "000" + scoreLeft.ToString ();
		} else if (scoreLeft < 1000) {
			scoreText.text = "00" + scoreLeft.ToString ();
		} else if (scoreLeft < 10000) {
			scoreText.text = "0" + scoreLeft.ToString ();
		} else {
			scoreText.text = scoreLeft.ToString ();
		} 
		mb.hideMole (molNummer - 1);
		ActiveMoles.RemoveAt(ActiveMoles.IndexOf (molNummer));

		} 

}
}
