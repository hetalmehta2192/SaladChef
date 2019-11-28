﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class PickUpVeggie
{
	public float choppingTime;
	public Veggies name;
}

public enum Veggies
{
	A,
	B,
	C,
	D,
	E,
	F
}

[Serializable]
public class PickUp:PickUpVeggie
{
	public float remainingTime;
	public State curState;

	public enum State
	{
		Chopping,
		Chopped,
		Wait
	}

	//To Freez player
	public  void StartChopping (PlayerController playerObj)
	{
	}
	//To change state of pickup item
	public  void UpdateState (State newState)
	{
	}
}