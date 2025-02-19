using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
	[SerializeField] public GameObject mainUI;
	[SerializeField] GameObject interactableUI;
	protected virtual void OnInteract()
	{
		mainUI.SetActive(true);
	} 

	protected virtual void ExitPlayer()
	{
		mainUI.SetActive(false);
	}
	public void CloseUI()
	{
		mainUI.SetActive(false);
	}

	public void ClickInteractiveButton()
	{
		OnInteract(); 
	}

	protected virtual void Awake()
	{
		mainUI.SetActive(false); 
		interactableUI.SetActive(false);
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
			interactableUI.SetActive(true);
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
			interactableUI.SetActive(false);
			ExitPlayer();
		}

	}
}
