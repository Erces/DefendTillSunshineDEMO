using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class MonstersRock : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnEnable()
    {
        transform.DOScale(new Vector3(transform.localScale.x * 2f, transform.localScale.y * 2f, transform.localScale.z * 2f), 0.3f).SetLoops(1, LoopType.Yoyo);
    }
}
