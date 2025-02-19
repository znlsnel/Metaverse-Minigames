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
	[SerializeField] Text gold;

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
	private void Start()
	{
		DataManager.instance.inventory.InitEquipItems();
	}


	void SortItemList()
	{
		InventoryDataSO idata = DataManager.instance.inventory;
		List<string> myItem = idata.myItems;

		
		equipSlot.InitSlot();

		int idx = 0;
		foreach (var item in myItem)
		{
			var go = DataManager.instance.GetItem(item);
			var itemData = go.GetComponent<ItemData>();

			if (idata.isEquiped(itemData))
			{
				go.SetActive(true); 
				equipSlot.SetSlot(itemData.image, itemData.name);
				continue;
			}
			 
			itemSlots[idx].SetSlot(itemData.image, itemData.name);
			idx++;
		}

		for (int i = idx; i < itemSlots.Count; i++)
				itemSlots[i].InitSlot();
		

	}



	public void EquipItem()
	{
		string name = itemSlots[selectItemIdx].name;
		var itemData = DataManager.instance.GetItem(name).GetComponent<ItemData>();

		DataManager.instance.inventory.EquipItem(itemData);

		SortItemList();
		CloseEquipUI();
	}


	public void OpenUI()
	{
		gold.text = DataManager.instance.inventory.gold.ToString();

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


	public void UnEquip()
	{ 
		if (equipSlot.name.Length == 0)
			return;

		var itemData = DataManager.instance.GetItem(equipSlot.name).GetComponent<ItemData>();
		DataManager.instance.inventory.EquipItem(itemData);
		SortItemList(); 
	}

}
