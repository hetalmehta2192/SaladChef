using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.AI;
using UnityEngine.UI;

public enum PlayerName
{
	Red,
	Blue
}

[Serializable]
public class PlayerController:MonoBehaviour
{
	private NavMeshAgent agent;
	private int pickupChopIndex;
	public PlayerName pName;
	public Score scoreObj;
	public InputManager inputObj;
	public PlayerTimer timerObj;
	public List<PickUp> pickUps;

	public List<PickUp> PickUps {
		get {
			if (pickUps == null) {
				pickUps = new List<PickUp> ();
			}
			return pickUps;
		}
		set {
			pickUps = value;
		}
	}

	private static int maxPickUps = 2;

	public delegate void PickToContainer (PlayerName pName, Veggies vName);

	public delegate void CleanContainer (PlayerName pName);

	public static event PickToContainer dAddPickToContainer;
	public static event CleanContainer dRemovePickToContainer;

	public delegate void SpawnPowerUp (PlayerName pName);

	public static event SpawnPowerUp dSpawnPowerUp;

	void Start ()
	{
		agent = GetComponent<NavMeshAgent> ();
		scoreObj.CurScore = 0;
		InvokeRepeating ("StartCountdown", 1f, 1f);
	}

	void Update ()
	{
		MovementCheck ();
	}

	public void StartCountdown ()
	{
		timerObj.CurTimerValue++;
	}

	//Update player movement
	public void MovementCheck ()
	{
		inputObj.CkeckInput (agent);
	}

	void PreparePickup (Collider colObj)
	{
		if (PickUps.Count < maxPickUps) {
			PickUp newVeggie = colObj.GetComponent<GeneratePickUp> ().GetPickUp ();
			if (newVeggie != null) {
				AddPickUp (newVeggie);
			}
		}
	}

	//before start chopping veggies update staes and index
	void PrepareChopping ()
	{
		if (pickupChopIndex < PickUps.Count) {
			PickUp curPickup = PickUps [pickupChopIndex];
			curPickup.curState = PickUp.State.Chopping;
			inputObj.IsFreezed = true;
			StartCoroutine (StartChopping (curPickup));
		}
	}

	//before throwing veggies to dustbin prepare
	void PrepareCleaning ()
	{
		if (PickUps.Count > 0) {
			PickUps.RemoveAt (0);
			pickupChopIndex--;
			dRemovePickToContainer (pName);
		}
	}

	void PrepareToSearve (PlayerReward result)
	{
		switch (result) {
		case PlayerReward.Ideal:
			Debug.Log ("Ideal !");
			break;
		case PlayerReward.Reward:
			Debug.Log ("Rewarded !");
			dSpawnPowerUp (pName);
			break;
		case PlayerReward.Panelty:
			Debug.Log ("Penality !");
			GivePunishment ();
			break;
		}
		ResetPlayer ();
	}

	void ResetPlayer ()
	{
		for (int i = PickUps.Count - 1; i >= 0; i--) {
			dRemovePickToContainer (pName);
		}
		pickupChopIndex = 0;
	}

	public void GivePunishment ()
	{
		scoreObj.CurScore -= 10f;
	}

	//detect kind of player interacting with
	private void OnTriggerStay (Collider colObj)
	{
		if (Input.GetKeyDown (inputObj.pickUpInput)) {
			//veggie pickup
			if (colObj.CompareTag ("PickUp")) {
				PreparePickup (colObj);
			} else if (colObj.CompareTag ("Board")) {
				PrepareChopping ();
			} else if (colObj.CompareTag ("Bin")) {			
				PrepareCleaning ();
			} else if (colObj.CompareTag ("PowerUp")) {			
				PrepareCleaning ();
			} else if (colObj.CompareTag ("Customer")) {			
				PrepareToSearve (colObj.GetComponent<CustomerContoller> ().cusObj.VerifySalad (PickUps));
			}
		}
	}

	//when chopping starts freez player
	private IEnumerator StartChopping (PickUp curPickup)
	{
		while (curPickup.remainingTime > 0) {
			curPickup.remainingTime -= Time.deltaTime;
			inputObj.barUI.fillAmount = curPickup.remainingTime / curPickup.choppingTime;
			yield return new WaitForEndOfFrame ();
		}
		curPickup.curState = PickUp.State.Chopped;
		inputObj.IsFreezed = false;
		pickupChopIndex++;
	}
	
	//Add new veggie
	public void AddPickUp (PickUp newVeggie)
	{		
		if (!PickUps.Contains (newVeggie)) {
			PickUps.Add (newVeggie);
			dAddPickToContainer (pName, newVeggie.vName);
		}
	}

	//When player pick up any reward
	public void AddPowerUp (PowerUpType type)
	{
	}
}
