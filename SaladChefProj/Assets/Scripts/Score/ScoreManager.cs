using System;
using UnityEngine.UI;

[Serializable]
public class Score
{
	private float m_curScore;
	public Text scoreTxt;

	public float CurScore {
		get {
			return m_curScore;
		}
		set {
			m_curScore = value;
			scoreTxt.text = m_curScore.ToString ();
		}
	}
}
