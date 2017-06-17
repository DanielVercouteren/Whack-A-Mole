using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class rsgTextScript : MonoBehaviour {
	public Text rsgText;
	string text1 = "Ready?";
	string text2 = "Set?";
	string text3 = "Go!!";

	// Use this for initialization
	void Start () {
		StartCoroutine (countDown ());
	}

	private IEnumerator countDown(){
		//Wait for 1000ms. before counting down
		yield return new WaitForSeconds(1f);
		rsgText.text = text1;
		//Show 1700ms.
		yield return new WaitForSeconds(1.7f);
		rsgText.text = text2;
		//Show 1700ms.
		yield return new WaitForSeconds(1.7f);
		rsgText.text = text3;
		//Show 600ms.
		yield return new WaitForSeconds(0.6f);
		rsgText.enabled = false;
	}
}
