using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputDetector : MonoBehaviour {



	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (2)) {

			int index = Random.Range (0, 9);
			KanpsackManager.Instance.StoreItem (index);
		}
	}
}
