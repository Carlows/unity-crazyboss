using UnityEngine;
using System.Collections;

public class HealthGUI : MonoBehaviour {

	public float barDisplay = 0;
	private Vector2 pos = new Vector2(80, Screen.height - 40);
	private Vector2 size = new Vector2(200, 40);
	public Texture2D progressBarEmpty;
	public Texture2D progressBarFull;
	public GUISkin mySkin;

	private Health playerh;

	void Start()
	{
		playerh = GetComponent<Health> ();
		if( playerh != null )
		{
			barDisplay = playerh.playerHealth / 100.0f;
		}
		else
		{
			Debug.LogError("No se pudo encontrar el script Health");
		}
	}

	void OnGUI()
	{
		GUI.skin = mySkin;
		// draw the background:
		GUI.BeginGroup (new Rect (pos.x, pos.y, size.x, size.y));
		GUI.Box (new Rect (0,0, size.x, size.y),progressBarEmpty);
		// draw the filled-in part:
		GUI.BeginGroup (new Rect (0, 0, size.x * barDisplay, size.y));
		GUI.Box (new Rect (0, 0, size.x, size.y), progressBarFull);
		GUI.EndGroup ();
		GUI.Label (new Rect (0, -2, size.x, size.y), "" + playerh.playerHealth);
		
		GUI.EndGroup ();
	}

	void Update()
	{
		barDisplay = playerh.playerHealth / 100.0f;
	}
}

