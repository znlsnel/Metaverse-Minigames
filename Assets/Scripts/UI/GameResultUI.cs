using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class GameResultUI : MonoBehaviour
{
	[SerializeField] GameObject panel;
    [SerializeField] Text gameName;
    [SerializeField] Text bestScore;
    [SerializeField] Text reward;

	public void Start()
	{
		panel.SetActive(false);
		var rd = DataManager.instance.resultData;
		if (rd.gameName == "")
			return;
		

		gameName.text = rd.gameName;
		bestScore.text = rd.bestScore.ToString();
		reward.text = rd.reward.ToString();
		panel.SetActive(true);

		DataManager.instance.inventory.gold += rd.reward;

		rd.gameName = "";
		rd.reward = 0;
		rd.bestScore = 0;
	}

	public void CloseUI()
	{
		panel.SetActive(false);

	}
}
