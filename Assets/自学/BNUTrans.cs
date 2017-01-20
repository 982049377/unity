using UnityEngine;
using System.Collections;

public class BNUTrans : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//this.transform.Rotate (2, 2, 2);
		this.transform.Translate (this.transform.up);
	}
}
