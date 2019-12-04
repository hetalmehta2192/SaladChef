using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratePickUp : MonoBehaviour
{
	public	Veggies veggieName;

	public PickUp GetPickUp ()
	{
		PickUp newVeggie =	GetComponentInParent<PickUpController> ().GetVeggie (veggieName);
		if (newVeggie != null) {
			newVeggie.remainingTime = newVeggie.choppingTime;
		}
		return newVeggie;
	}

	//	private void OnTriggerStay (Collider colObj)
	//	{
	//		if (colObj.CompareTag ("Player")) {
	//			PickUp newVeggie =	GetComponentInParent<PickUpController> ().GetVeggie (veggieName);
	//			if (newVeggie != null) {
	//				newVeggie.remainingTime = newVeggie.choppingTime;
	//				colObj.GetComponent<PlayerController> ().AddPickUp (newVeggie);
	//			}
	//		}
	//	}
}
