using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogUI : InteractableObject
{
    // Start is called before the first frame update
    [SerializeField] DialogDataSO startDialog;
    [SerializeField] List<GameObject> playerAnswers = new List<GameObject>(); // 일단 사이즈가 3개

    [SerializeField] Text npcText;

	protected override void OnInteract()
    {
        base.OnInteract();
        foreach (var btn in playerAnswers)
            btn.SetActive(false);

        UpdateDialogUI(startDialog);
	}

    void UpdateDialogUI(DialogDataSO dialog)
    {
        if (dialog == null)
        {
            CloseUI();
            return;
		}

		npcText.text = dialog.npcText;

        // 플레이어 선택지만큼 버튼 활성화
        for (int i = 0; i < dialog.response.Count; i++)
        {
            int idx = i;
            playerAnswers[i].GetComponent<Button>().onClick.RemoveAllListeners();

            // 버튼이 클릭되면 UpdateDialogUI가 다시 호출되도록 구현
			playerAnswers[i].GetComponent<Button>().onClick.AddListener(() =>
            { 
                UpdateDialogUI(dialog.response[idx].nextDialogue); 
            });

            playerAnswers[i].GetComponentInChildren<Text>().text = dialog.response[i].playerText;
			playerAnswers[i].SetActive(true); 
        }

        // 사용되지 않는 버튼 비활성화
        for (int i = dialog.response.Count; i < playerAnswers.Count; i++)
            playerAnswers[i].SetActive(false);

	}
} 
