using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InteractableObject : MonoBehaviour
{
	[SerializeField] GameObject interactableUI;
	protected abstract void OnInteract();
	protected abstract void ExitPlayer();

	public void ClickInteractiveButton()
	{
	//	InputSystem.instance.SetActiveInputSystem(false);
		OnInteract(); 
	}

	private void Awake()
	{
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
