using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlotUI : MonoBehaviour
{
    public Action onClickButton;
    public Image image;
	public string name = "";

    public void ClickButton() 
    {
        if (name == "")
            return;

        onClickButton?.Invoke();  
	} 

    public bool isEmpty()
    {
        return name == "";
    }

    public void SetSlot(Image image, string name)
    {
        this.image.sprite = image.sprite;
        this.image.color = image.color;
        this.name = name;   
    }
	public void SetSlot(SpriteRenderer image, string name)
	{
		this.image.sprite = image.sprite;
		this.image.color = image.color;
		this.name = name;
	}

	public void InitSlot()
    {
        image.sprite = null;
        image.color = Color.white;
		name = ""; 
	}
}
