using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

[CreateAssetMenu(fileName = "InventoryData", menuName = "MySO/inventoryData")]
public class InventoryDataSO : ScriptableObject
{
    public int gold;

    public List<string> myItems = new List<string>();
    HashSet<string> myItemHash = new HashSet<string>();

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

    public bool isEquiped(ItemData item)
    {
        return helmet == item.name || vehicle == item.name;
    }
    public void InitEquipItems()
    {
        if (helmet.Length > 0)
        {
			var item = DataManager.instance.GetItem(helmet).GetComponent<ItemData>();
			EquipItem(item); 
			EquipItem(item); 
		}

		if (vehicle.Length > 0)
		{
			var item = DataManager.instance.GetItem(vehicle).GetComponent<ItemData>();
			EquipItem(item);
			EquipItem(item); 
		}

	}    
    public void EquipItem(ItemData item)
    {

        if (item.type == EItemType.HELMET)
        {
            if (helmet.Length > 0)
			    DataManager.instance.GetItem(helmet).SetActive(false);

			if (helmet == item.name)
                helmet = "";
            else
            {
                helmet = item.name;
				DataManager.instance.GetItem(item.name).SetActive(true);
			} 
		}
        else
        {
            if (vehicle.Length > 0)
			    DataManager.instance.GetItem(vehicle).SetActive(false);

			if (vehicle == item.name) 
				vehicle = "";
			else  
			{
				vehicle = item.name;
				DataManager.instance.GetItem(item.name).SetActive(true);
			}
		}
    }


}
