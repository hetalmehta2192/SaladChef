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
	private int pickupChopIndex;

	void Start ()
	{
		agent = GetComponent<NavMeshAgent> ();
	}

	void Update ()
	{
		MovementCheck ();
	}

	//Update player movement
	public void MovementCheck ()
	{
		inputObj.CkeckInput (agent);
	}

	void PreparePickup (Collider colObj)
	{
		PickUp newVeggie = colObj.GetComponent<GeneratePickUp> ().GetPickUp ();
		if (newVeggie != null) {
			AddPickUp (newVeggie);
		}
	}

	//before start chopping veggies update staes and index
	void PrepareChopping ()
	{
		if (pickupChopIndex < pickUps.Count) {
			PickUp curPickup = pickUps [pickupChopIndex];
			curPickup.curState = PickUp.State.Chopping;
			inputObj.isFreezed = true;
			StartCoroutine (StartChopping (curPickup));
		}
	}

	//before throwing veggies to dustbin prepare
	void PrepareCleaning ()
	{
		if (pickUps.Count > 0) {
			pickUps.RemoveAt (0);
			pickupChopIndex--;
		}
	}

	//detect kind of player interacting with
	private void OnTriggerStay (Collider colObj)
	{
		if (Input.GetKeyDown (inputObj.pickUpInput)) {
			//veggie pickup
			if (colObj.CompareTag ("PickUp")) {
				PreparePickup (colObj);
			}
			if (colObj.CompareTag ("Board")) {
				PrepareChopping ();
			}
			if (colObj.CompareTag ("Bin")) {			
				PrepareCleaning ();
			}
		}
	}

	//when chopping starts freez player
	private IEnumerator StartChopping (PickUp curPickup)
	{
		yield return new WaitForSecondsRealtime (curPickup.remainingTime);
		curPickup.curState = PickUp.State.Chopped;
		inputObj.isFreezed = false;
		pickupChopIndex++;
	}
	
	//Add new veggie
	public void AddPickUp (PickUp newVeggie)
	{
		if (Input.GetKeyDown ((inputObj.pickUpInput))) {
			if (pickUps == null) {
				pickUps = new List<PickUp> ();
			}
			if (!pickUps.Contains (newVeggie)) {
				pickUps.Add (newVeggie);
			}
		}
	}

	//When player pick up any reward
	public void AddPowerUp (PowerUpType type)
	{
	}
}
