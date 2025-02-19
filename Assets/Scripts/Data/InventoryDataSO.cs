using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "InventoryData", menuName = "MySO/inventoryData")]
public class InventoryDataSO : ScriptableObject
{
    public int gold;
    public List<string> myItems = new List<string>();
    public string helmet = "";
    public string vehicle = "";

    public void AddItem(ItemData item) 
    {
		myItems.Add(item.name);
    }

    public bool HasItem(ItemData item)
    {
        return myItems.Contains(item.name);
    } 
     
    public void EquipItem(ItemData item)
    {

        if (item.type == EItemType.HELMET)
        {
            if (helmet == item.name)
            {
                DataManager.instance.GetItem(item.name).SetActive(false);
                helmet = "";
			}
            else
            {
                helmet = item.name;
				DataManager.instance.GetItem(item.name).SetActive(true);
			} 
		}
        else
        {
			if (vehicle == item.name)
			{
				DataManager.instance.GetItem(item.name).SetActive(false);
				vehicle = "";
			}
			else 
			{
				vehicle = item.name;
				DataManager.instance.GetItem(item.name).SetActive(true);
			}
		}
    }


}
