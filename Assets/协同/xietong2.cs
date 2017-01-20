using UnityEngine;
using System.Collections;

public class xietong2 : MonoBehaviour {

	IEnumerator Start() {
		print("Starting " + Time.time);
		yield return StartCoroutine(WaitAndPrint(2.0F));
		print("Done " + Time.time);
	}
	IEnumerator WaitAndPrint(float waitTime) {
		yield return new WaitForSeconds(waitTime);
		print("WaitAndPrint " + Time.time);
	}
}
