using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.AI;
using UnityEngine.UI;
using System.Threading;

[Serializable]
public class InputManager
{
	public float moveSpeed = 2f;
	public List<InputClass> inputs;
	public KeyCode pickUpInput;
	public Image barUI;
	private bool isFreezed;

	public bool IsFreezed {
		get {
			return isFreezed;
		}
		set {
			isFreezed = value;
			if (isFreezed) {
//				Thread t = new Thread (StartChoopingTimer);
//				t.Start ();
				//StartChoopingTimer ();
			} else {
				barUI.fillAmount = 1f;
			}
		}
	}

	//	private void StartChoopingTimer ()
	//	{
	//		while (isFreezed)
	//			barUI.fillAmount -= Time.smoothDeltaTime;
	//	}

	public void CkeckInput (NavMeshAgent playerObj)
	{
		if (!IsFreezed) {
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