using UnityEngine;
using System.Collections;

public class xiecheng : MonoBehaviour {

	// Use this for initialization
	void Start () {
		// - After 0 seconds, prints "Starting 0.0"
		// - After 0 seconds, prints "Before WaitAndPrint Finishes 0.0"
		// - After 2 seconds, prints "WaitAndPrint 2.0"
		// 先打印"Starting 0.0"和"Before WaitAndPrint Finishes 0.0"两句,2秒后打印"WaitAndPrint 2.0"
		print ("Starting " + Time.time );
		// Start function WaitAndPrint as a coroutine. And continue execution while it is running
		// this is the same as WaintAndPrint(2.0) as the compiler does it for you automatically
		// 协同程序WaitAndPrint在Start函数内执行,可以视同于它与Start函数同步执行.
		StartCoroutine(WaitAndPrint(2.0f)); 
		print ("Before WaitAndPrint Finishes " + Time.time );
	}
	
	// Update is called once per frame
	void Update () {
	
	}
		
	IEnumerator WaitAndPrint (float waitTime) {
		// suspend execution for waitTime seconds
		// 暂停执行waitTime秒
		yield return new WaitForSeconds (waitTime);
		print ("WaitAndPrint "+ Time.time );
	}

}
