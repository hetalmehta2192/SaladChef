using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.AI;

[Serializable]
public class InputManager
{
	public bool isFreezed;
	public float moveSpeed = 2f;
	public List<InputClass> inputs;

	public void CkeckInput (NavMeshAgent playerObj)
	{
		for (int i = 0; i < inputs.Count; i++) {
			if (Input.GetKey (inputs [i].inputKey)) {
				Vector3 newPos = Vector3.zero;
				switch (inputs [i].direction) {
				case InputDirection.Up:
					newPos = Vector3.left * Time.deltaTime * moveSpeed;
					break;
				case InputDirection.Down:
					newPos = -Vector3.left * Time.deltaTime * moveSpeed;
					break;
				case InputDirection.Right:
					newPos = Vector3.forward * Time.deltaTime * moveSpeed;
					break;
				case InputDirection.Left:
					newPos = -Vector3.forward * Time.deltaTime * moveSpeed;
					break;
				}
				playerObj.Move (newPos);
			}
		}
	}
}

public enum InputDirection
{
	Up,
	Down,
	Left,
	Right}
;

[Serializable]
public class InputClass
{
	public InputDirection direction;
	public KeyCode inputKey;
}