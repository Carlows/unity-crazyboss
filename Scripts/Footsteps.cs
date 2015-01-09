using UnityEngine;
using System.Collections;

public class Footsteps : MonoBehaviour {

	private FirstPersonHeadBob fpsHead;

	[SerializeField] AudioClip[] footstepWoodSounds;
	[SerializeField] AudioClip[] footstepGrassSounds;

	// Use this for initialization
	void Start () {
		fpsHead = GetComponent<FirstPersonHeadBob> ();
		if( fpsHead == null )
		{
			Debug.LogError("FirstPersonHeadBob no se encontro");
		}
		if (audio == null)
		{
			// we automatically add an audiosource, if one has not been manually added.
			gameObject.AddComponent<AudioSource>();
		}
	}
	
	// Update is called once per frame
	void Update () {
		if( fpsHead.DoingFootstep )
		{
			RaycastHit hit;

			if( Physics.Raycast(transform.position, -transform.up, out hit, 3 ) )
			{
				if( hit.collider.gameObject.tag == "Terrain" )
				{
					//Debug.Log("Estoy sobre el terreno");
					// excluding sound at index 0
					int n = Random.Range(1,footstepGrassSounds.Length);
					audio.clip = footstepGrassSounds[n];
					audio.Play();
					
					// move picked sound to index 0 so it's not picked next time
					footstepGrassSounds[n] = footstepGrassSounds[0];
					footstepGrassSounds[0] = audio.clip;

					fpsHead.DoingFootstep = false;
				}
				else
				{
					// excluding sound at index 0
					int n = Random.Range(1,footstepWoodSounds.Length);
					audio.clip = footstepWoodSounds[n];
					audio.Play();
					
					// move picked sound to index 0 so it's not picked next time
					footstepWoodSounds[n] = footstepWoodSounds[0];
					footstepWoodSounds[0] = audio.clip;
					
					fpsHead.DoingFootstep = false;
				}
			}
		}
	}
}
