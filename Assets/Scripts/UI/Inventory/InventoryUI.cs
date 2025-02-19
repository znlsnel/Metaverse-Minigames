using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
	[SerializeField] ItemSlotUI equipSlot; 
	[Space(10)]

    [SerializeField] GameObject equipPanel;
    [SerializeField] GameObject inventoryPanel;
    [SerializeField] GameObject closeBtn;
	[Space(10)]

	[SerializeField] GameObject ItemListUI;

	List<ItemSlotUI> itemSlots = new List<ItemSlotUI>();

	int selectItemIdx = -1;
	private void Awake()
	{
		CloseUI();
		int cnt = ItemListUI.transform.childCount;
        for (int i = 0; i < cnt; i++)
        {
			var slot = ItemListUI.transform.GetChild(i).GetComponent<ItemSlotUI>();
			if (slot != null)
			{
				int num = i;
				slot.onClickButton = ()=>OpenEquipUI(num); 
				itemSlots.Add(slot);
			} 
		} 
    }

	void SortItemList()
	{
		List<string> myItem = DataManager.instance.inventory.myItems;

		int idx = 0;
		foreach (var item in myItem)
		{
			if (item == equipSlot.name)
				continue;

			var itemData = DataManager.instance.GetItem(item).GetComponent<ItemData>();
			itemSlots[idx].SetSlot(itemData.image, itemData.name);
			idx++;
		}
		
		for (int i = idx; i < itemSlots.Count; i++)
		{
			if (i >= myItem.Count)
				itemSlots[i].InitSlot();
		}

	}

	public void EquipItem()
	{
		string name = itemSlots[selectItemIdx].name;
		var itemData = DataManager.instance.GetItem(name).GetComponent<ItemData>();

		DataManager.instance.inventory.EquipItem(itemData);
		itemSlots[selectItemIdx].InitSlot();

		if (equipSlot.isEmpty() == false)
			itemSlots[selectItemIdx].SetSlot(equipSlot.image, equipSlot.name);

		equipSlot.SetSlot(itemData.image, itemData.name);

		CloseEquipUI();
		SortItemList();
	}


	public void OpenUI()
	{
		SortItemList();
		inventoryPanel.SetActive(true);
		closeBtn.SetActive(true);
    }
    public void CloseUI()
    {
		inventoryPanel.SetActive(false);
		equipPanel.SetActive(false);
		closeBtn.SetActive(false);
	}
	void OpenEquipUI(int idx)
	{
		equipPanel.SetActive(true);
		selectItemIdx = idx;
	}
	public void CloseEquipUI()
	{
		equipPanel.SetActive(false);
		selectItemIdx = -1;
	}




}
