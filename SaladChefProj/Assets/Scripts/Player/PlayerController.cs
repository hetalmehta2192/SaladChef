using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.AI;

[Serializable]
public class PlayerController:MonoBehaviour
{
	public Score scoreObj;
	public InputManager inputObj;
	public List<PickUp> pickUps;
	private NavMeshAgent agent;

	void Start ()
	{
		agent = GetComponent<NavMeshAgent> ();
	}

	void Update ()
	{
		MovementCheck ();
	}

	public void MovementCheck ()
	{
		inputObj.CkeckInput (agent);
	}

	public void AddPickUp (PowerUpType type)
	{
	}
}
