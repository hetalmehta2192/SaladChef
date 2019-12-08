using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
	private int totalCustomerCnt;

	void Start ()
	{
		totalCustomerCnt = GameObject.FindGameObjectsWithTag ("Customer").Length;
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	public void UpdateCustomerLeftCnt ()
	{
		if (Customer.totalCusLeft >= totalCustomerCnt) {

		}
	}
}
