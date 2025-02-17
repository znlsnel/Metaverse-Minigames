using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputSystem : Singleton<InputSystem>   
{
    [SerializeField] public InputActionAsset inputActionMap;
    [SerializeField] public InputActionReference click;
    [SerializeField] public InputActionReference position;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
