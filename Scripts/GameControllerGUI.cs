using UnityEngine;
using System; 
using System.Collections.Generic;

public class GameControllerGUI : MonoBehaviour {

	public GUISkin mySkin;
	private GameController gController;

	// Use this for initialization
	void Start () {
		gController = GameObject.FindGameObjectWithTag ("GameController")
								.GetComponent<GameController> ();
	}

	void OnGUI()
	{
		GUI.skin = mySkin;	
		GUILayout.BeginArea (new Rect (10, 10, 400, 400));
		foreach(Assignment a in gController.assignments)
		{
			if( a.NumberOfThingsToFind == 0 )
			{
				GUILayout.Label(String.Format("{0}", a.JobText));
			}
			else
			{
				GUILayout.Label(String.Format("{0} {1}", a.JobText, (a.NumberOfThingsToFind - a.ThingsFound)));
			}
		}
		GUILayout.EndArea ();
	}
}
