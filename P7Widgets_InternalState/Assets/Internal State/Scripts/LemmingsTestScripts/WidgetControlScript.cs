using UnityEngine;
using System.Collections;

/*
 * This script is placed on the widget gameObjects in the scene. 
 * It contains the controls of the widgets and the tools chosen by the user.
 */

public class WidgetControlScript : MonoBehaviour {

	public int _widgetIndex;									//The index of the widget, to compare with settings in Widget Detection Algorithm gameObject.
	Transform _myTransform;
	Transform _toolMount;
	[SerializeField] private bool _buttonIsHeld = false;		//Flag for whether or not the button on this widget is held in
	private WidgetDetectionAlgorithm _widgetAlgorithm;		//instance of the widget algorithm


	void Start () {
		_widgetAlgorithm = WidgetDetectionAlgorithm.instance;
		_myTransform = transform;
		_toolMount = _myTransform.FindChild("ToolMount");
	}
	


	void Update () {
		UpdateWidgetInfo();

		if(_buttonIsHeld)
		{
			print("I'm touching the widget button!");
		}
	}



	// Updates the position, orientation and button checks of the widget
	void UpdateWidgetInfo()
	{
		if(_widgetAlgorithm.widgets.Length == 0)
		{
			SetVisibility(false);
		}

		foreach(Widget w in _widgetAlgorithm.widgets)
		{
			if(w.flags.Contains(_widgetIndex))
			{
				// Position and orientation
				MoveWidget(w);
				//Make visible
				SetVisibility(true);
				// Button check for flag id 3
				_buttonIsHeld = CheckButton(w, 3);
				return;
			} else
			{
				//Make invisible
				SetVisibility(false);
			}
		}
	}



	void MoveWidget(Widget w)
	{
		//Position
		transform.position = Camera.main.ScreenToWorldPoint(w.position) + Vector3.forward;

		//Rotation
		float angle = Vector3.Angle(Vector3.down, w.orientation) * Mathf.Sign(w.orientation.x);
		transform.eulerAngles = Vector3.forward * angle;
	}



	bool CheckButton(Widget w, int flagID)
	{
		//Button
		if(w.flags.Contains(flagID))
		{
			return true;
		} else
		{
			return false;
		}
	}



	void SetVisibility(bool b)
	{
		print(b);
		foreach(Transform child in _toolMount)
		{

			//Disable/enable renderer
			if(child.GetComponent<SpriteRenderer>())
			{
				child.GetComponent<SpriteRenderer>().enabled = b;
			}

			//Disable/enable tool script

			//.....
		}
	}
}