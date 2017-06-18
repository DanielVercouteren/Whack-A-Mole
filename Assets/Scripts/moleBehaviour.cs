using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class moleBehaviour : MonoBehaviour {
	GameObject[] ObjectList;
	GameObject[] MolesList;
	public int amountOfMoles = 8;

	public GameObject[] findMoles(){
		MolesList = new GameObject[amountOfMoles];

		//Get all GameObjects
		ObjectList = GameObject.FindObjectsOfType<GameObject> ();

		//Filter GameObjects for "Mol "
		foreach (GameObject singleObject in ObjectList) {
			if (singleObject.name.StartsWith ("Mol ")) {
				//Get the position and place in MolesList
				string position = singleObject.name.Replace ("Mol ", "");
				Debug.Log ("Object found: " + position);
				MolesList [int.Parse (position) - 1] = singleObject;
			}
		}

		for(int i = 0; i <= MolesList.Length; i++){
			Debug.Log("Mole: " + MolesList[i].name);
		}
			
		return  MolesList;
	}

	public void popupMole(int mole){
		MolesList [mole].SetActive (true);
	}

	public void hideMole(int mole){
		MolesList [mole].SetActive (false);
	}
}
