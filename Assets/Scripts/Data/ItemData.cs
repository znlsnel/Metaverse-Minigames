using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EItemType
{
    HELMET,
    VEHICLE
}
public class ItemData : MonoBehaviour
{
    public SpriteRenderer image;
    public string name;
    public string description;
    public int price;
    public EItemType type; 


}


