using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
	private int totalCustomerCnt;
	[SerializeField]
	private GameObject winerPanel, uiPanel;
	[SerializeField]
	private GameWinner winerPlayer = null;
	public static GameController controllerObj;


	private bool playerLifeTime = false;

	public bool PlayerLifeTime {
		get {
			return playerLifeTime;
		}
		set {
			playerLifeTime = value;
			if (playerLifeTime)
				GameResult ();
		}
	}

	void Awake ()
	{
		controllerObj = this;
	}

	void Start ()
	{
		UpdateUI (true);
		totalCustomerCnt = GameObject.FindGameObjectsWithTag ("Customer").Length;
	}

	void UpdateUI (bool flag)
	{
		winerPanel.SetActive (!flag);
		uiPanel.SetActive (flag);
	}

	public void UpdatePlayerScore (PlayerName pName, int score)
	{
		if (winerPlayer == null) {
			winerPlayer.UpdateWinner (pName, score);
		} else if (winerPlayer.pName != pName) {
			if (winerPlayer.score < score) {
				winerPlayer.UpdateWinner (pName, score);
			} else {
				//Its Tie
				winerPlayer.UpdateTextForTie ();
			}
		}
	}

	public void UpdateCustomerLeftCnt ()
	{
		if (Customer.totalCusLeft >= totalCustomerCnt) {
			GameResult ();
		}
	}

	public void RestartGame ()
	{
		Debug.Log ("RestartGame");
		SceneManager.LoadScene (0);
	}

	void GameResult ()
	{
		Debug.Log ("Winder is : " + winerPlayer.pName + " Score : " + winerPlayer.score);
		UpdateUI (false);
	}

}

[Serializable]
public class GameWinner
{
	public PlayerName pName;
	public int score;
	[SerializeField]
	private Text txtWin;

	public void UpdateWinner (PlayerName pName, int score)
	{
		this.pName = pName;
		this.score = score;
		txtWin.text = "Winner : " + pName + " Score : " + score;
	}

	public void UpdateTextForTie ()
	{
		txtWin.text = "Its Tie !!";
	}
}