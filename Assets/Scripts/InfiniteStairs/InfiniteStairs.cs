using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Diagnostics;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.Pool;
using UnityEngine.SceneManagement;
using static Unity.Collections.AllocatorManager;

public class InfiniteStairs : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject block;
	[SerializeField] GameScoreUI scoreUI; 

	Queue<GameObject> blocks = new Queue<GameObject>();

	GameObject curBlock;

	float offsetX = 1.0f;
	float offsetY = 0.5f;
	int y = -3;
	int x = 0;
	float prevX = 0;
	float prevY = 0;
	int length = 2;

	private void Awake()
	{
		player.transform.position = new Vector3(x-1, y - 0.5f, 0);
		var tmp = Instantiate<GameObject>(block);
		tmp.transform.position = new Vector3(x, y, 0);
		blocks.Enqueue(tmp);
		prevX = x;
		prevY = y;

		int cnt = 20;
		while (cnt-- > 0)
		{  
			int dir = UnityEngine.Random.Range(0, 2) == 0 ? -1 : 1;
			if (Math.Abs(prevX + dir) > length)
				dir *= -1;

			float nextX = prevX + (dir * offsetX); 

			var go = Instantiate<GameObject>(block);
			go.transform.position = new Vector3(nextX, prevY + offsetY, 0);
			blocks.Enqueue(go);

			prevX = nextX;
			prevY += offsetY;
		}

	}
	private void Start()
	{
		InputSystem.instance.leftArrow.action.performed += OnLeftButton;
		InputSystem.instance.rightArrow.action.performed += OnRightButton;
	}

	private void OnDestroy() 
	{
		//DiableInputKey(); 
	}
	 
	void DiableInputKey()
	{
		InputSystem.instance.leftArrow.action.performed -= OnLeftButton;
		InputSystem.instance.rightArrow.action.performed -= OnRightButton;
	}
	void GameOver()
	{
		DiableInputKey();
		player.AddComponent<Rigidbody2D>();
		scoreUI.GameOver(); 
	}
	void OnLeftButton(InputAction.CallbackContext obj) 
	{
		var pos = player.transform.position;
		pos.y += offsetY;
		pos.x -= offsetX;
		player.transform.position = pos;
		PlayerMove();
	}

	void OnRightButton(InputAction.CallbackContext obj)
	{
		var pos = player.transform.position;
		pos.y += offsetY;
		pos.x += offsetX;
		player.transform.position = pos;
		PlayerMove();
	} 

	void PlayerMove()
	{
		scoreUI.StartGame();
		var prevBlock = curBlock;
		curBlock = blocks.Dequeue();

		if (prevBlock != null)
		{
			MoveBlock(prevBlock);
		} 

		if ((player.transform.position - curBlock.transform.position).magnitude > 1.0f)
		{
			GameOver();
			return;
		}
		scoreUI.AddScore();
	}

	void MoveBlock(GameObject block)
	{
		int dir = UnityEngine.Random.Range(0, 2) == 0 ? -1 : 1;
		if (Math.Abs(prevX + dir) > length)
			dir *= -1;

		float nextX = prevX + (dir * offsetX);

		block.transform.position = new Vector3(nextX, prevY + offsetY, 0);
		blocks.Enqueue(block);

		prevX = nextX; 
		prevY += offsetY;
	}


}
