using System;
using UnityEngine;
using System.Collections.Generic;

public class PickUpController:MonoBehaviour
{
	public List<PickUp> availPickUp;

	public PickUp GetVeggie (Veggies veggieName)
	{
		return availPickUp.Find (x => x.name == veggieName);
	}
}