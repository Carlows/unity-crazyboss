using UnityEngine;
using System.Collections;

public class LakeDamage : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}

	void OnTriggerEnter(Collider other)
	{
		Destroy(other.gameObject);
	}
}
