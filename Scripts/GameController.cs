using UnityEngine;
using System.Collections.Generic;
using System;

public class GameController : MonoBehaviour {

	public List<Assignment> assignments = new List<Assignment>();
	public bool BossFase = false;

	public GameObject ItemsParent;
	public GameObject[] prefabs;

	private GameObject[] _SpawnPoints;

	// Use this for initialization
	void Start () {
		_SpawnPoints = GameObject.FindGameObjectsWithTag("Spawners");
				
		//Debug.Log(String.Format("{0}, {1}, {2}", Terrain.activeTerrain.terrainData.size.x, Terrain.activeTerrain.terrainData.size.y, Terrain.activeTerrain.terrainData.size.z));
		// Populate World with Items!
		PopulateItems();

		assignments.Add (new Assignment { JobText = "Habla con la secretaria", JobCode = "secretaria", NumberOfThingsToFind = 0, ThingsFound = -1 });
	}
	
	// Update is called once per frame
	void Update () {
		for( int a = 0; a < assignments.Count; a++ )
		{
			assignments[a].CheckIfDone();
			if( assignments[a].Completed )
			{
				assignments.RemoveAt(a);
			}
		}

		if( assignments.Count == 0 )
		{
			Debug.Log ("Todas las asignaciones se cumplieron!");
			assignments.Add(new Assignment { JobText = "Entregale todo a la secretaria!", JobCode = "secretaria2", NumberOfThingsToFind = 0, ThingsFound = -1 });
			BossFase = true;
		}		
	}

	void PopulateItems()
	{
		for( int i = 0; i < _SpawnPoints.Length; i++ )
		{
			for( int p = 0; p < prefabs.Length; p++ )
			{
				int numberObjectsBySpawnPoint = UnityEngine.Random.Range(2, 5);
				for( int x = 0; x < numberObjectsBySpawnPoint; x++ )
				{
					Vector3 position = _SpawnPoints[i].transform.position 
						+ new Vector3(UnityEngine.Random.Range(-500, 500), 0, UnityEngine.Random.Range(-500, 500));
					//Debug.Log(String.Format("{0}, {1}", position.x, position.z));
					position.y = Terrain.activeTerrain.SampleHeight(position) + 3.0f;
					
					var go = Instantiate(prefabs[p], position, Quaternion.identity) as GameObject;
					go.transform.parent = ItemsParent.transform;
				}
			}
		}
	}
}
