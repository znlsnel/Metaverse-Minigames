using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour
{
	[SerializeField] GameScoreSO scoreData;
    [SerializeField] Text scoreText;
	[SerializeField] Text gameOverText;
	[SerializeField] GameObject retryBtn;
	[SerializeField] GameObject effect;

	int score = 0;

    void Start()
    {

		gameOverText.gameObject.SetActive(false);
		retryBtn.SetActive(false);
		effect.SetActive(false);	
		StartCoroutine(UpdateScore());
    }
	 
	public void OpenUI()
	{
		if (scoreData.bestScore < scoreData.curScore)
		{
			gameOverText.text = "Best Score ! !";
			effect.SetActive(true);
		}
		else 
			gameOverText.text = "Game Over . .";

		scoreData.UpdateBestScore();
		gameOverText.gameObject.SetActive(true);
		retryBtn.SetActive(true);
	}

	IEnumerator UpdateScore()
    {
		float time = 1.5f;

		float score = 0;
		int target = scoreData.curScore;

		float d = scoreData.curScore / time;
		 
		while (time > 0)
		{
			time -= Time.deltaTime;
			score += d * Time.deltaTime;
			scoreText.text = ((int)score).ToString();
			yield return null;
		}
		scoreText.text = target.ToString();
	}

    
}
