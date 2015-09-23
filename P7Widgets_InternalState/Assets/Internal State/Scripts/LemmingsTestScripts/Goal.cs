using UnityEngine;
using System.Collections;

public class Goal : MonoBehaviour {

	float _timeBeforeDestroy = 1.2f;

	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.tag == "Lemming")
		{
			print("Lemming reached goal!");
			Destroy(col.gameObject, _timeBeforeDestroy);
		}
	}
}