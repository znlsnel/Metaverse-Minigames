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
        for (int i = 0; i < dialog.response.Count; i++)
        {
            int idx = i;
            playerAnswers[i].GetComponent<Button>().onClick.RemoveAllListeners();
			playerAnswers[i].GetComponent<Button>().onClick.AddListener(() =>
            { 
                UpdateDialogUI(dialog.response[idx].nextDialogue); 
            });

            playerAnswers[i].GetComponentInChildren<Text>().text = dialog.response[i].playerText;
			playerAnswers[i].SetActive(true); 
        }

        for (int i = dialog.response.Count; i < playerAnswers.Count; i++)
            playerAnswers[i].SetActive(false);

	}
} 
