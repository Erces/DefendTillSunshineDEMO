using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class SeerStone : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Vector3 target = new Vector3(0, 0.3f, 0);
        transform.DOMove(transform.position + target, 5).SetLoops(-1, LoopType.Yoyo);
        Vector3 rotateVector = new Vector3(0, 180, 0);
        transform.DORotate(Quaternion.ToEulerAngles(transform.localRotation) + rotateVector, 5).SetLoops(-1, LoopType.Yoyo);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 target = new Vector3(0, 0.5f, 0);
        Vector3 rotateVector = new Vector3(0, 180, 0);
        Vector3 scale = new Vector3(2, 2, 2);

        // transform.DOMove(transform.position + target, 1).SetLoops(-1,LoopType.Yoyo);
        //transform.DORotate(Quaternion.ToEulerAngles(transform.localRotation) + rotateVector, 1).SetLoops(-1, LoopType.Incremental);
      //  transform.DOScale(transform.localScale * 0.3f, 2).SetLoops(-1, LoopType.Yoyo);
    }
}
