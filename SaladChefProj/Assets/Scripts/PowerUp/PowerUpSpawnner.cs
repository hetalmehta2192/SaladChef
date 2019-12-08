using System;
using UnityEngine;

public class PowerUpSpawnner:MonoBehaviour
{
	[SerializeField]
	private GameObject powerUpPrefab;

	private void Start ()
	{
		PlayerController.dSpawnPowerUp += GetRandomPower;
	}


	public void GetRandomPower (PlayerName pName)
	{
		PowerUpType powerType = (PowerUpType)UnityEngine.Random.Range (0, 2);
		GameObject powerObj = Instantiate (powerUpPrefab);
		powerObj.transform.position = new Vector3 (UnityEngine.Random.Range (-1f, 1f), 1f, UnityEngine.Random.Range (-1f, 1f));
		PowerUp obj = powerObj.GetComponent <PowerUp> ();
		obj.SetPowerUp (powerType, pName);
	}
}