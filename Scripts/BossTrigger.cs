using UnityEngine;
using System.Collections;
using System;

public class BossTrigger : MonoBehaviour {

	private GameController gController;
	public bool TalkedToMe = false;
	public bool BossFaseOn = false;
	// Use this for initialization
	void Start () {
		gController = GameObject.FindGameObjectWithTag ("GameController")
								.GetComponent<GameController> ();
	}

	void OnTriggerEnter()
	{
		this.collider.enabled = false;
		gController.assignments.Clear ();

		if( !TalkedToMe )
		{
			GivePlayerRandomAssignments ();
			TalkedToMe = true;
		}
		else
		{
			// TIME TO FIGHT, BITCH!!!
			Debug.Log("TIME TO FIGHT, BITCH!");
			BossFaseOn = true;
		}
	}

	void Update()
	{
		if( gController.BossFase && !BossFaseOn )
		{
			this.collider.enabled = true;
		}
	}

	void GivePlayerRandomAssignments()
	{
		int numberOfThings = UnityEngine.Random.Range (2, 6);

		Assignment assignment = new Assignment
		{
			JobText = String.Format("Consigue frascos de azucar:"),
			JobCode = "azucar",
			ThingToFind = Things.Azucar,
			NumberOfThingsToFind = numberOfThings
		};

		numberOfThings = UnityEngine.Random.Range (2, 6);

		Assignment assignment2 = new Assignment
		{
			JobText = String.Format("Consigue semillas de cafe:"),
			JobCode = "semillas",
			ThingToFind = Things.Semillas,
			NumberOfThingsToFind = numberOfThings
		};

		numberOfThings = UnityEngine.Random.Range (2, 6);

		Assignment assignment3 = new Assignment
		{
			JobText = String.Format("Consigue botellas de agua:"),
			JobCode = "agua",
			ThingToFind = Things.Agua,
			NumberOfThingsToFind = numberOfThings
		};

		gController.assignments.Add (assignment);
		gController.assignments.Add (assignment2);
		gController.assignments.Add (assignment3);

	}
}
