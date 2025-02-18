using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : Singleton<DataManager>
{
    public int theStackScore = 0;
    public int theStackCombo = 0;
    public int theStackBestScore = 0;
    public int theStackBestCombo = 0;

    public void UpdateBestScore()
    {
        if (theStackScore > theStackBestScore)
			theStackBestScore = theStackScore;

        if (theStackCombo > theStackBestCombo)
			theStackBestCombo = theStackCombo;
	}
}
