using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoardUI : InteractableObject
{
	[SerializeField] Text scoreText;
	[SerializeField] List<GameScoreSO> scores = new List<GameScoreSO>();

	protected override void Awake()
	{
		base.Awake();
		scoreText.text = "";

		foreach (var score in scores)
			scoreText.text += $"{score.name} : {score.bestScore}\n";
	} 
} 
