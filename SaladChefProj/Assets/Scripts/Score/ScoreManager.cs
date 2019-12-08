using System;
using UnityEngine.UI;

[Serializable]
public class Score
{
	private int m_curScore;
	public Text scoreTxt;

	public int CurScore {
		get {
			return m_curScore;
		}
		set {
			m_curScore = value;
			scoreTxt.text = m_curScore.ToString ();
		}
	}
}
