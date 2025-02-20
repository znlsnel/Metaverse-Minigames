using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : Singleton<DataManager>
{
	public InventoryDataSO inventory;
	[SerializeField] List<GameObject> itemPrefabs = new List<GameObject>();
	Dictionary<string, GameObject> items = new Dictionary<string, GameObject>();
	public GameResultData resultData = new GameResultData();
	public GameScoreSO gameScoreData;

	public void InitItem()
	{
		items.Clear();
		foreach (var item in itemPrefabs)
		{
			ItemData id = item.GetComponent<ItemData>();
			var go = Instantiate<GameObject>(item);
			go.SetActive(false);
			items.Add(id.name, go);
		}
	}

	public List<GameObject> GetItems()
	{
		List<GameObject> list = new List<GameObject>();
        foreach (var item in items)
			list.Add(item.Value);

        return list;
	}
	 
	public GameObject GetItem(string name)
	{
		var player = MainScene.instance.player;
		var go = items[name];
		if (player != null)
		{
			go.transform.position = player.transform.position;
			go.transform.SetParent(player.transform);
			go.transform.localScale = Vector3.one;
		} 
		return go; 
	} 

}
