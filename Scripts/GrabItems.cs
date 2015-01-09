using UnityEngine;
using System.Collections;

public class GrabItems : MonoBehaviour {

	private GameController gController;

	// Use this for initialization
	void Start () {
		gController = GameObject.FindGameObjectWithTag("GameController")
								.GetComponent<GameController>();
	}
	
	// Update is called once per frame
	void Update () {
		if( Input.GetKeyDown(KeyCode.E) )
		{
			RaycastHit hit;
			Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
			if( Physics.Raycast( ray, out hit, 3 ) )
			{
				if( hit.collider.tag == "Item" )
				{
					Things itemType = hit.collider.GetComponent<ItemType>().Type;

					foreach( Assignment a in gController.assignments )
					{
						if( a.ThingToFind == itemType )
						{
							// Player found me!
							Debug.Log ("Player found me");
							a.FoundThing();					
							Destroy(hit.collider.gameObject);
						}
					}
				}
			}
		}
	}	
}
