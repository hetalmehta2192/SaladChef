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

	void PrepareChopping ()
	{
		if (pickupChopIndex < pickUps.Count) {
			PickUp curPickup = pickUps [pickupChopIndex];
			curPickup.curState = PickUp.State.Chopping;
			inputObj.isFreezed = true;
			StartCoroutine (StartChopping (curPickup));
		}
	}

	void PrepareCleaning ()
	{
		if (pickUps.Count > 0) {
			pickUps.RemoveAt (0);
			pickupChopIndex--;
		}
	}

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

	private IEnumerator StartChopping (PickUp curPickup)
	{
		yield return new WaitForSecondsRealtime (curPickup.remainingTime);
		curPickup.curState = PickUp.State.Chopped;
		inputObj.isFreezed = false;
		pickupChopIndex++;
	}

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

	public void AddPowerUp (PowerUpType type)
	{
	}
}
