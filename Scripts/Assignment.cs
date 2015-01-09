using UnityEngine;
using System.Collections.Generic;

public class Assignment{
	public bool Completed { get; set; }
	public string JobText { get; set; }
	public string JobCode { get; set; }
	public Things ThingToFind { get; set; }
	public int NumberOfThingsToFind { get; set; }
	public int ThingsFound { get; set; }

	public Assignment()
	{
		Completed = false;
		ThingsFound = 0;
	}

	public void CheckIfDone()
	{
		if( this.ThingsFound >= this.NumberOfThingsToFind )
		{
			Completed = true;
		}
	}

	public void FoundThing()
	{
		ThingsFound++;
	}
}

public enum Things
{
	Semillas,
	Agua,
	Azucar
}
