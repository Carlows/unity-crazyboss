using UnityEngine;
using System.Collections;

public class ItemCollectable : MonoBehaviour {

	private GameController gController;
	private Things itemType;

	// Use this for initialization
	void Start () {
		gController = GameObject.FindGameObjectWithTag("GameController")
								.GetComponent<GameController>();

		itemType = GetComponent<ItemType>().Type;
	}

	void OnTriggerEnter(Collider other)
	{
		if( other.tag == "Player" )
		{
			foreach( Assignment a in gController.assignments )
			{
				if( a.ThingToFind == itemType )
				{
					// Player found me!
					a.FoundThing();					
					Destroy(gameObject);
				}
			}
		}
	}

	// Update is called once per frame
	void Update () {
	
	}
}
