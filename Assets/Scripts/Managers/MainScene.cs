using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScene : MonoBehaviour
{
    public GameObject player;
   public static MainScene instance;
    void Awake()
    {
        instance = this;
        DataManager.instance.InitItem();
	}

	private void Start()
	{

	}
}
