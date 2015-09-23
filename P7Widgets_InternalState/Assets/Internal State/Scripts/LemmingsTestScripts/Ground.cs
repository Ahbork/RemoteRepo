using UnityEngine;
using System.Collections;

public class Ground : MonoBehaviour {

		
	void Start () {
	
	}
	


	void Update () {
	
	}



	//void OnCollisionEnter2D(Collision2D col)
	//{
	//	if(col.gameObject.tag == "Lemming")
	//	{
	//		col.gameObject.GetComponent<LemmingMovement>().Grounded = true;
	//	}
	//}



	void OnCollisionExit2D(Collision2D col)
	{
		if(col.gameObject.tag == "Lemming")
		{
			col.gameObject.GetComponent<LemmingMovement>().Grounded = false;
		}
	}



	void OnCollisionStay2D(Collision2D col)
	{
		if(col.gameObject.tag == "Lemming" && col.gameObject.GetComponent<LemmingMovement>().Grounded == false)
		{
			col.gameObject.GetComponent<LemmingMovement>().Grounded = true;
		}
	}
}