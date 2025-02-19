using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Diagnostics;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TheStackScoreUI : MonoBehaviour
{
    [SerializeField] GameScoreSO scoreData;
    [Space(10)]

	[SerializeField] Text MyBestScoreText;
	[SerializeField] Text scoreText;

    [SerializeField] GameObject ComboGO;
    [SerializeField] TextMeshProUGUI comboText;
    [Space(10)]
    [SerializeField] GameObject touchPad;
    [SerializeField] GameObject startButton;

    int score = 0;
    int combo = 0; 
    int bestCombo = 0;
	private void Awake()
	{
		ComboGO.SetActive(false);
		scoreText.text = score.ToString();

		scoreText.gameObject.SetActive(false);

        MyBestScoreText.text = scoreData.bestScore.ToString();
	}
	public void AddScore()
    {
        score++;
		scoreText.text = score.ToString();
	}

	public void AddCombo()
    {
        combo++; 
        if (combo > 0)
        {
			ComboGO.SetActive(false);
			ComboGO.SetActive(true);
			comboText.text = combo.ToString();
		}

        if (combo > bestCombo)
        {
			bestCombo = combo;
		}
        score += combo;
		scoreText.text = score.ToString();
	}

	public void ResetCombo()
    {
        combo = 0;
    }

    public void GameOver() 
    {
        touchPad.SetActive(false);
		scoreData.curScore= score;

        MYMetaverse.instance.SetTimer(() =>
        {
            SceneManager.LoadScene("TheStackGameOver");
        }, 2.0f);
	}

    public void StartGame()
    {
		startButton.SetActive(false);
		scoreText.gameObject.SetActive(true);
	}
}
