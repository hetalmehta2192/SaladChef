using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerContoller : MonoBehaviour
{

	public Customer cusObj;

	// Use this for initialization
	void Start ()
	{
		cusObj.Init ();
		StartCoroutine (Timer ());
	}

	IEnumerator Timer ()
	{
		while (!(cusObj.IsLeft || cusObj.IsSatisfied)) {
			cusObj.UpdateLifeTime ();
			yield return new WaitForEndOfFrame ();
		}
		cusObj.LifeTime = 0;
	}
}
