using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.AI;
using UnityEngine.UI;

[Serializable]
public class PlayerTimer
{
	private int m_curTimerValue = 50;
	//250;
	public Text timerTxt;

	public int CurTimerValue {
		get {
			return m_curTimerValue;
		}
		set {
			m_curTimerValue = value;
			timerTxt.text = m_curTimerValue.ToString ();
		}
	}
}



