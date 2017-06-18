using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class moleBehaviour : MonoBehaviour {
	List<GameObject> MolesList = new List<GameObject>();

	public List<GameObject> findMoles(){
		GameObject[] amountOfMoles = GameObject.FindObjectsOfType<GameObject>();
		foreach (GameObject mole in amountOfMoles) {
			if(mole.name.StartsWith("Mol ")){
				MolesList.Add(mole);
			}
		}
		return MolesList;
	}

	public void popupMole(int mole){
		MolesList [mole].SetActive (true);
	}

	public void hideMole(int mole){
		MolesList [mole].SetActive (false);
	}
}
