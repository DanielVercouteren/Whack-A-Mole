using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class showMole : MonoBehaviour {
	moleBehaviour mb = new moleBehaviour();
	List<GameObject> Moles;
	List<int> ActiveMoles;

	int numOfMoles;
	int randomMole;

	public int maxMoles = 7;
	public float waitingtime = 4.0f;

	void Start(){
		Moles = new List<GameObject>();
		ActiveMoles = new List<int> ();

		Moles = mb.findMoles ();

		foreach (GameObject mole in Moles) {
			mole.SetActive (false);
			numOfMoles++;
		}
			
		InvokeRepeating ("moleAnimation", 7.0f, maxMoles);
	}

	void moleAnimation(){
		//Check how many moles are on the screen
		if (ActiveMoles.Count < maxMoles) {
			randomMole = Random.Range(0, numOfMoles);

			//Make sure no mol is already shown
			while (ActiveMoles.Contains (randomMole)) {
				Debug.Log ("Mole #" + randomMole + " already exists!");
				randomMole = Random.Range(1, numOfMoles);
			}

			Debug.Log ("Will show mole #" + randomMole);
			ActiveMoles.Add (randomMole);
			mb.popupMole (randomMole);
		} else {
			//Hide longest waiting mol
			Debug.Log("Will hide mole #" + ActiveMoles[0]);
			mb.hideMole (ActiveMoles[0]);
			ActiveMoles.Remove(ActiveMoles[0]);

			//Repeat process
			moleAnimation ();
		}
	}
}
