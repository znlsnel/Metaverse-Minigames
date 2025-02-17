using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogUI : InteractableObject
{
	[SerializeField] GameObject scoreUI;

	private void Awake()
	{
		scoreUI.SetActive(false);
	}
	protected override void OnInteract()
	{
		scoreUI.SetActive(true);
	}
	protected override void ExitPlayer()
	{
		scoreUI.SetActive(false);
	}
	public void CloseUI()
	{
		scoreUI.SetActive(false);
	}

}
