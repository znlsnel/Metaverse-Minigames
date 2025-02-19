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
    [SerializeField] GameObject issuPanel;
    [SerializeField] Text issuText;

    void Start()
    {
        issuPanel.SetActive(false);

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

		Debug.Log($"������ ���� : {name}");
        var go = db.GetItem(name);
        issuText.text = "������ ���ſ� �����߽��ϴ�!";

        var itemData = go.GetComponent<ItemData>();
        
		if (id.HasItem(itemData) == false)
        {
			if (id.gold < itemData.price)
				issuText.text = "��尡 �����մϴ�.";

            else
            {
				id.AddItem(go.GetComponent<ItemData>());
                id.gold -= itemData.price;

				gold.text = id.gold.ToString();
			}
		}
		else
			issuText.text = "�̹� ������ �������Դϴ�.";

		 
		issuPanel.SetActive(true);
	}

    public void CloseIssuePanel()
    {
		issuPanel.SetActive(false);

	}
}  
