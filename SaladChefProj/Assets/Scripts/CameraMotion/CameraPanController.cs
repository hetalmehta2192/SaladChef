using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CameraPanController : MonoBehaviour
{
	[SerializeField]
	public float m_zoomSpeed = 1.5f;

	// Update is called once per frame
	void Update ()
	{
		transform.position += Vector3.up * Time.deltaTime * Input.mouseScrollDelta.y;
	}
	//	public class CameraPan
	//	{
	//		public KeyCode m_zoomInKey;
	//		public KeyCode m_zoomOutKey;
	//	}
}
