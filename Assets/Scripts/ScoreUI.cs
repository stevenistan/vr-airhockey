using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour {
	private int scorePlayer = 0;
	private int scoreAI = 0;
	public TextMesh scoreText;

	void Start () {
		UpdateUI ();
	}

	public void ScorePlayer () {
		scorePlayer += 1;
		UpdateUI ();
	}

	public void ScoreAI () {
		scoreAI += 1;
		UpdateUI ();
	}

	private void UpdateUI () {
		scoreText.text = scorePlayer.ToString () + " - " + scoreAI.ToString ();
	}

}
