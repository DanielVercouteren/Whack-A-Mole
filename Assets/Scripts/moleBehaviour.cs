using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class moleBehaviour : MonoBehaviour {
	GameObject[] MolesList;

	//Has to be public! showMole gets this int.
	public int amountOfMoles = 16;

	public List<GameObject> findMoles(){
		MolesList = new GameObject[amountOfMoles];

		//Get all GameObjects
		foreach (GameObject singleObject in GameObject.FindObjectsOfType<GameObject> ()) {
			if (singleObject.name.StartsWith ("Mol ")) {
				//Get the position and place in MolesList at the correct position
				string position = singleObject.name.Replace ("Mol ", "");
				MolesList [int.Parse (position) - 1] = singleObject;
			}
		}

		List<GameObject> returnList = new List<GameObject> ();
		//Add all objects to a List
		for (int i = 0; i < MolesList.Length; i++) {
			returnList.Add (MolesList [i]);
		}
		return returnList;
	}

	public void popupMole(int mole){
		MolesList [mole].SetActive (true);
	}

	public void hideMole(int mole){
		MolesList [mole].SetActive (false);
	}
}
