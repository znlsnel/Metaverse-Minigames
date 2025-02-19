using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Store : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject itemUIPrefab;
    [SerializeField] GameObject itemParent;

    void Start()
    { 
        List<GameObject> list = DataManager.instance.GetItems();
        foreach (GameObject item in list)
        {
            ItemData id = item.GetComponent<ItemData>();
            var go = Instantiate<GameObject>(itemUIPrefab);
            go.GetComponent<StoreItemUI>().InitItemUI(id.image, id.name, id.price, ()=>BuyItem(id.name)); 
            go.transform.SetParent(itemParent.transform, false);  
        }
	}

    void BuyItem(string name)
    {
        DataManager db = DataManager.instance;
        InventoryDataSO id = db.inventory;

		Debug.Log($"아이템 구매 : {name}");
        var go = db.GetItem(name);

        if (id.HasItem(go.GetComponent<ItemData>()) == false)
            id.AddItem(go.GetComponent<ItemData>());
        else
            Debug.Log("이미 소유한 아이템입니다."); 
	}
}  
