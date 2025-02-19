using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreItemUI : MonoBehaviour
{
    Action onClick;
    public Image image;
    public Text name;
    public Text price;

   public void InitItemUI(SpriteRenderer sr, string name, int p, Action action)
    {
        image.sprite = sr.sprite;
        image.color = sr.color;
        this.name.text = name; 
        this.price.text = p.ToString();
		onClick = action;
	}

    public void OnClick()
    {
        onClick?.Invoke();
	}
}
