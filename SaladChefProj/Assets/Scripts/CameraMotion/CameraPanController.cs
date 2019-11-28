using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CameraPanController : MonoBehaviour
{
	[SerializeField]
	public float zoomSpeed = 1.5f;
	private Vector3 m_originalPos;
	private float distanceLimit = 0.5f;

	void Start ()
	{
		m_originalPos = transform.position;
	}

	// Update is called once per frame
	void Update ()
	{
		if (Input.mouseScrollDelta.y != 0) {
			Vector3 newPos = transform.position + Vector3.up * Time.deltaTime * Input.mouseScrollDelta.y * zoomSpeed;
			if (m_originalPos.y + distanceLimit > newPos.y && m_originalPos.y - distanceLimit < newPos.y)
				transform.position = newPos;
		}
	}
}
