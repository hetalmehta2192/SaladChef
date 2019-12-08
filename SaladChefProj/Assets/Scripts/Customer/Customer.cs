using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

[Serializable]
public class Customer
{
	public List<Veggies> Order;
	public float timeCounterSpeed;
	private float totalWaitTime = 1000f;
	private float remainingWaitTime;
	private float angerRatio = 0.001f;
	private float angerLevel = 1f;
	private bool isSatisfied = false, m_isLeft = false;
	[SerializeField]
	private Image imgBarUI;
	[SerializeField]
	private Text OrderTxt;

	public bool IsSatisfied {
		get { return isSatisfied; }
		set{ isSatisfied = value; }
	}

	public bool IsLeft {
		get{ return m_isLeft; }
		set {
			m_isLeft = value;
		}
	}

	public float LifeTime {
		get{ return remainingWaitTime; }
		set {
			remainingWaitTime = value;
			if (remainingWaitTime > 0) {					 
				if (imgBarUI != null) {
					imgBarUI.fillAmount = remainingWaitTime / totalWaitTime;
				}
			} else {
				IsLeft = true;
				if (!IsSatisfied)
					GivePenaltyPlayer ();
			}
		}
	}

	public void updateLifeTime ()
	{			
		LifeTime -= angerRatio * angerLevel / Time.deltaTime;
	}

	public void init ()
	{
		totalWaitTime *= Order.Count;
		remainingWaitTime = totalWaitTime;
		string orderStr = "";
		for (int i = 0; i < Order.Count; i++) {
			orderStr += Order [i];
			if (i < Order.Count - 1) {
				orderStr += ",";
			}
		}
		OrderTxt.text = orderStr;
	}

	public PlayerReward VerifySalad (List<PickUp> pickUps)
	{
		if (pickUps == null || pickUps.Count != Order.Count) {
			//punish player
			return PlayerReward.Panelty;
		}
		for (int i = 0; i < Order.Count; i++) {			
			if (pickUps.Find (k => k.vName == Order [i]) == null) {
				Debug.Log ("Salad is not Valid !");
				angerLevel++;
				//p.Punish ();
				return PlayerReward.Panelty;
			}
		}
		IsSatisfied = true;
		if (remainingWaitTime >= totalWaitTime * 0.7f) {
			//Reward player
			return PlayerReward.Reward;
		}
		return PlayerReward.Ideal;
	}

	//Give Penalty to all player if customer left angry
	void GivePenaltyPlayer ()
	{
		foreach (var item in GameObject.FindGameObjectsWithTag ("Player")) {
			PlayerController playerObj = item.GetComponent <PlayerController> ();
			playerObj.GivePunishment ();
		}
	}
}

public enum PlayerReward
{
	Panelty,
	Reward,
	Ideal
}
