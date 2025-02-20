using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputSystem : Singleton<InputSystem>   
{
    [SerializeField] public InputActionAsset inputActionMap;
    [SerializeField] public InputActionReference click;
    [SerializeField] public InputActionReference position;
    [SerializeField] public InputActionReference leftArrow;
    [SerializeField] public InputActionReference rightArrow;

	protected override void Awake()
	{
        base.Awake();
        inputActionMap.Enable(); 
	}

    public void SetActiveInputSystem(bool active)
    {
        if (active)
		    inputActionMap.Enable();
        else
		    inputActionMap.Disable();

	}

}
