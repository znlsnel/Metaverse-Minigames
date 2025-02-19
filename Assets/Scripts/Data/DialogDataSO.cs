using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DialogueData", menuName = "MySO/DialogueData")]


[Serializable]
public class PlayerResponse
{
    public DialogDataSO nextDialogue;

    [TextArea(3, 10)]
    public string playerText; 
}

public class DialogDataSO : ScriptableObject
{
    [TextArea(5, 20)]
    public string npcText;
    public List<PlayerResponse> response = new List<PlayerResponse>();
}
