using UnityEngine;
using System.Collections;

public class LemmingMovement : MonoBehaviour 
{

	Rigidbody2D _rigid;			//The rigidbody component
	float _speed = 300f;
	float _decelerationSpeed = 0.96f;
	float _decelerationSpeedFalling = 0.98f;
	bool _grounded = false;



	void Awake () 
	{
		_rigid = this.GetComponent<Rigidbody2D>();
	}
	


	void Update ()
	{
		UpdateGravity();
		UpdateMovement();
	}



	void UpdateGravity()
	{
		if(_grounded)
			_rigid.velocity *= _decelerationSpeed;
		else
			_rigid.velocity *= _decelerationSpeedFalling;
	}



	void UpdateMovement()
	{
		if(_grounded)
			_rigid.AddForce(new Vector2(_speed, 0) * Time.deltaTime);
	}



	public bool Grounded
	{
		get { return _grounded; }
		set { _grounded = value; }
	}
}