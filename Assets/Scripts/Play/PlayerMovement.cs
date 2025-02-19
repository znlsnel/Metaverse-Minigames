using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    InputSystem input;

	SpriteRenderer sr;
	Rigidbody2D rigid;
	Animator anim;

	Vector3 prevTouchPos;
	bool isMoving = false;

	float Xsize = 0;
	private void Awake()
	{
        input = InputSystem.instance;
		input.click.action.performed += OnClick;
		input.click.action.canceled += OnClickRelase;
		Xsize = gameObject.transform.localScale.x;
		sr = GetComponent<SpriteRenderer>();
		rigid = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
	}
	private void OnDestroy()
	{
		input.click.action.performed -= OnClick;
		input.click.action.canceled -= OnClickRelase;
	}

	void FixedUpdate()
	{
		OnMove();
	}
	void OnMove()
	{
		if (isMoving == false)
			return;

		Vector2 dir = (Input.mousePosition - prevTouchPos);
		if (dir.magnitude < 0.1f)
			return;

		anim.SetBool("run", true);
		rigid.MovePosition(rigid.position + (dir.normalized * Time.fixedDeltaTime * 3.0f));

		//sr.flipX = dir.x < 0;
		var s = gameObject.transform.localScale;
		s.x = dir.x < 0 ? -Xsize : Xsize; 
		gameObject.transform.localScale = s;
	}

	void OnClick(InputAction.CallbackContext obj)
	{
		isMoving = true;
		prevTouchPos = Input.mousePosition;
	}

	void OnClickRelase(InputAction.CallbackContext obj)
	{
		isMoving = false;
		anim.SetBool("run", false);
	}


}
