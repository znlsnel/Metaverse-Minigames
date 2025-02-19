using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewScoreData", menuName = "MySO/ScoreData")]
public class GameScoreSO : ScriptableObject
{
    public string name;
	public int curScore;
	public int bestScore;

	public void UpdateBestScore()
	{
		if (curScore > bestScore) 
			bestScore = curScore;
	}
}
 