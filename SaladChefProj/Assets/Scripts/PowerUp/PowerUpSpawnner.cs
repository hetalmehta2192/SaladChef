using System;
using UnityEngine;

public class PowerUpSpawnner:MonoBehaviour
{
	public GameObject powerUpPrefab;

	private void Start ()
	{
		PlayerController.dSpawnPowerUp += GetRandomPower;
	}


	public void GetRandomPower (PlayerName pName)
	{
		PowerUpType powerType = (PowerUpType)UnityEngine.Random.Range (0, 4);
		GameObject powerObj = Instantiate (powerUpPrefab);
		powerObj.transform.position = new Vector3 (UnityEngine.Random.Range (-1, 1), UnityEngine.Random.Range (-1, 1));
		PowerUp obj = powerObj.GetComponent <PowerUp> ();
		obj.SetPowerUp (powerType, pName);
	}
}