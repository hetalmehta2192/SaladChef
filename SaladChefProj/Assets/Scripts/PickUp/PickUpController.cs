using System;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class PickUpController:MonoBehaviour
{
	public List<PickUp> availPickUp;
	public GameObject pickUpUIPrefab;
	public List<PickUpContainer> containerObj;

	private void Start ()
	{
		PlayerController.dAddPickToContainer += AddPickUp;
		PlayerController.dRemovePickFromContainer += RemovePickUp;
		PlayerController.dRemoveAllPickFromContainer += RemoveAllPickUp;
	}

	public void AddPickUp (PlayerName pName, Veggies vName)
	{
		PickUpContainer container = containerObj.Find (x => x.pName == pName);
		if (container != null) {
			GameObject newPickUp = Instantiate (pickUpUIPrefab);
			newPickUp.transform.GetComponentInChildren <Text> ().text = vName.ToString ();
			newPickUp.transform.SetParent (container.transContainer, false);
		}
	}

	public void RemovePickUp (PlayerName pName)
	{
		PickUpContainer container = containerObj.Find (x => x.pName == pName);
		if (container != null) {
			Destroy (container.transContainer.GetChild (0).gameObject);
		}
	}

	public void RemoveAllPickUp (PlayerName pName)
	{
		PickUpContainer container = containerObj.Find (x => x.pName == pName);
		if (container != null) {
			int cnt = container.transContainer.childCount;
			foreach (Transform item in container.transContainer.transform) {
				Destroy (item.gameObject);
			}
		}
	}

	public PickUp GetVeggie (Veggies veggieName)
	{
		return availPickUp.Find (x => x.vName == veggieName);
	}
}