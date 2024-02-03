using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class cloud : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DOTween.Init();
        transform.DOScale(new Vector3(transform.localScale.x * 0.85f, transform.localScale.y * 0.85f, transform.localScale.z * 0.85f), Random.Range(3,8)).SetLoops(-1, LoopType.Yoyo);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
