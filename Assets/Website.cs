using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Website : MonoBehaviour
{
    private void Start()
    {
        
        transform.DOScale(new Vector3(transform.localScale.x * 0.85f, transform.localScale.y * 0.85f, transform.localScale.z * 0.85f), 2).SetLoops(-1, LoopType.Yoyo);
    }
    public void WebsiteUrl()
    {
        Application.OpenURL("https://www.defendtillsunshine.com/");
    }
}
