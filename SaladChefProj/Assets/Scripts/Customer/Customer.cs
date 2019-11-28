using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Customer
{
	public List<PickUp> salad;
	public float totalWaitTime, remainingWaitTime;
	public float timeCounterSpeed;

	public bool VerifySalad (List<PickUp> newSalad)
	{
		return false;
	}
}
