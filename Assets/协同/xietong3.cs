using UnityEngine;
using System.Collections;

public class xietong3 : MonoBehaviour {
	IEnumerator Start() {
		StartCoroutine("DoSomething", 2.0F);
		yield return new WaitForSeconds(2);//2秒后停止
		StopCoroutine("DoSomething");
	}
	IEnumerator DoSomething(float someParameter) {
		while (true) {
			print("DoSomething Loop"+Time.time);
			yield return null;
		}
	}
}
