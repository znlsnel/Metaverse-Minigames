using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Store : MonoBehaviour
{
    [SerializeField] Text gold;
    [SerializeField] GameObject player;
    [SerializeField] GameObject itemUIPrefab;
    [SerializeField] GameObject itemParent;
    [SerializeField] GameObject popup;
    [SerializeField] Text issuText;

    void Start()
    {
        popup.SetActive(false);

		List<GameObject> list = DataManager.instance.GetItems();
        foreach (GameObject item in list)
        {
            ItemData id = item.GetComponent<ItemData>();
            var go = Instantiate<GameObject>(itemUIPrefab);
            go.GetComponent<StoreItemUI>().InitItemUI(id.image, id.name, id.price, ()=>BuyItem(id.name)); 
            go.transform.SetParent(itemParent.transform, false);  
        }
	}
	private void OnEnable()
	{
		InventoryDataSO id = DataManager.instance.inventory;
		gold.text = id.gold.ToString(); 
	}

	void BuyItem(string name)
    {
        DataManager db = DataManager.instance;
        InventoryDataSO id = db.inventory;

        var go = db.GetItem(name);
        var itemData = go.GetComponent<ItemData>();
        
        // ������ �������� �ƴ� ���
		if (id.HasItem(itemData) == false)
        {
            // ��尡 ������ ���
			if (id.gold < itemData.price)
				issuText.text = "��尡 �����մϴ�.";

            // ���Ű� ������ ���
            else
            {
				issuText.text = "������ ���ſ� �����߽��ϴ�!";
				id.AddItem(go.GetComponent<ItemData>());
                id.gold -= itemData.price;
				gold.text = id.gold.ToString();
			}
		}

        // �̹� ������ �������� ���
		else
			issuText.text = "�̹� ������ �������Դϴ�.";

		popup.SetActive(true);
	}

    public void CloseIssuePanel()
    {
		popup.SetActive(false);

	}
}  
