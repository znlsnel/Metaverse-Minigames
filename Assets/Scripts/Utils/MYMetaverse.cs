using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MYMetaverse : Singleton<MYMetaverse>
{
    // Start is called before the first frame update
    public void SetTimer(Action action, float time)
    {
        StartCoroutine(Timer(action, time));    
    }

    IEnumerator Timer(Action action, float time)
    {
        yield return new WaitForSeconds(time);
        action?.Invoke();
    }
}
