using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingUI : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject closeBtn;
    [SerializeField] GameObject settingPanel;

	private void Awake()
	{
        closeBtn.SetActive(false);
		settingPanel.SetActive(false);
	}
	
	public void OpenSetting()
	{
		closeBtn.SetActive(true);
		settingPanel.SetActive(true);
	}

	public void CloseSetting()
	{
		closeBtn.SetActive(false);
		settingPanel.SetActive(false);
	}

}
