using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp:MonoBehaviour
{
	private PowerUpType m_powerType;
	private PlayerName m_pName;
	[SerializeField]
	private TextMesh textObj;

	public void SetPowerUp (PowerUpType powerType, PlayerName pName)
	{
		m_pName = pName;
		m_powerType = powerType;
		textObj.text = "" + m_powerType;
	}

	private void OnTriggerStay (Collider colObj)
	{		
		if (colObj.CompareTag ("Player")) {
			AssignPowerUp (colObj.GetComponent<PlayerController> ());
		}
	}

	private void AssignPowerUp (PlayerController playerObj)
	{
		if (playerObj.pName == m_pName) {    
			switch (m_powerType) {
			case PowerUpType.SpeedUp:
				playerObj.inputObj.moveSpeed += 1f;
				break;
			case PowerUpType.ScoreUp:
				playerObj.scoreObj.CurScore += 50f;
				break;
			case PowerUpType.TimeUp:
				playerObj.timerObj.CurTimerValue -= 10;
				break;
			}
			Destroy (gameObject);
		}
	}
}

public enum PowerUpType
{
	SpeedUp,
	ScoreUp,
	TimeUp
}
