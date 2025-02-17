using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class JoystickUI : MonoBehaviour
{ 
	InputSystem input;
	[SerializeField] RectTransform outline;
    [SerializeField] RectTransform dirPoint; 
    [SerializeField] RectTransform touchPoint;

    Vector3 startPos = Vector3.zero;
	private void Awake()
	{
		input = InputSystem.instance;
		input.click.action.performed += OnClick;
		input.click.action.canceled += OnClickRelase;
		input.position.action.performed += UpdateHandPosition;
		gameObject.SetActive(false);
	}

    ~JoystickUI() 
    {
		input.click.action.performed -= OnClick;
		input.click.action.canceled -= OnClickRelase;
	}

	 void OnClick(InputAction.CallbackContext obj)
    {
        startPos = Input.mousePosition;
		outline.localPosition = outline.parent.InverseTransformPoint(startPos);
		touchPoint.localPosition = touchPoint.parent.InverseTransformPoint(startPos);
		dirPoint.localPosition = dirPoint.parent.InverseTransformPoint(startPos);
		
		gameObject.SetActive(true); 
	}

	void OnClickRelase(InputAction.CallbackContext obj)
    {
		gameObject.SetActive(false);

	}

	void UpdateHandPosition(InputAction.CallbackContext obj)
    { 
		Vector3 curPos = obj.ReadValue<Vector2>();
		touchPoint.localPosition = touchPoint.parent.InverseTransformPoint(curPos);

		Vector3 dir = (curPos - startPos).normalized;
		dirPoint.localPosition = outline.localPosition + dir * 30;

	}
}
