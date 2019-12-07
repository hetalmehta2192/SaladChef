using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerContoller : MonoBehaviour
{

	public Customer cusObj;

	// Use this for initialization
	void Start ()
	{
		cusObj.init ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		cusObj.updateLifeTime ();
	}
}
