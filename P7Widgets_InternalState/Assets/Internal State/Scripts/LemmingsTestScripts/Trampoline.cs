using UnityEngine;
using System.Collections;

public class Trampoline : MonoBehaviour {

	Vector2 _forceDirection = new Vector2(400,500);


	
	void Start () {
	
	}
	


	void Update () {
	
	}



	void OnCollisionEnter2D(Collision2D col)
	{
		if(col.gameObject.tag == "Lemming")
		{
			col.gameObject.GetComponent<Rigidbody2D>().AddForce(_forceDirection);
		}
	}
}