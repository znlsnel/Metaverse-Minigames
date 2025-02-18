using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TheStackScoreUI : MonoBehaviour
{
    [SerializeField] Text scoreText;
    [SerializeField] Text bestComboText;

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
		bestComboText.text = bestCombo.ToString();

		scoreText.gameObject.SetActive(false);
		bestComboText.gameObject.SetActive(false);
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
			bestComboText.text = bestCombo.ToString();
		}
	} 

    public void ResetCombo()
    {
        combo = 0;
    }

    public void GameOver()
    {
        touchPad.SetActive(false);

	}

    public void StartGame()
    {
		startButton.SetActive(false);
		scoreText.gameObject.SetActive(true);
		bestComboText.gameObject.SetActive(true);
	}
}
