using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class PickUpVeggie
{
	public float choppingTime;
	public Veggies vName;
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
		Ideal,
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

[Serializable]
public class PickUpContainer
{
	public Transform transContainer;
	public PlayerName pName;
}