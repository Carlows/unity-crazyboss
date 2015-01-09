using UnityEngine;
using System.Collections;

public class GUICrosshair : MonoBehaviour {
	public Texture2D crosshairTexture;
	public Rect position;
	public Transform asd;
	void Start () {
		position = new Rect((Screen.width - crosshairTexture.width) / 2, (Screen.height - 
		                                                              crosshairTexture.height) /2, crosshairTexture.width, crosshairTexture.height);
		Screen.showCursor = false;
	}
	
	void OnGUI()
	{
		GUI.DrawTexture(position, crosshairTexture);
	}
}