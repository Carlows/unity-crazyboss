using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

	public int playerHealth { get; set; }
	public float playerStamina { get; set; }
	private bool isDead = false;

	private float minStamina = 0;							// Min amount of stamina
	private float maxStamina = 100;							// Max amount of stamina
	private float rateStamina = 10.0f;						// Amount of stamina the player will drain every update
	private float canRunAgain = 25.0f;						// Amount of stamina the player needs to be able to run again

	public bool playerCanRun { get; set; }

	// Use this for initialization
	void Start () {
		playerHealth = 100;		
		playerStamina = 100;
		playerCanRun = true;
	}
	
	// Update is called once per frame
	void Update () {
		if( playerStamina <= 0 )
		{
			playerCanRun = false;
		}
		else if( playerStamina > canRunAgain )
		{
			playerCanRun = true;
		}

		if( Input.GetKey(KeyCode.LeftShift) && playerCanRun )
		{
			playerStamina -= rateStamina * Time.deltaTime;
		}
		else
		{
			playerStamina += (rateStamina / 2) * Time.deltaTime;
		}

		if( playerHealth <= 0 )
		{
			playerHealth = 0;
			isDead = true;
		}

		playerStamina = Mathf.Clamp(playerStamina, minStamina, maxStamina);
	}


}
