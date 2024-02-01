using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookingList : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [System.Obsolete]
    private void OnEnable()
    {
        MouseLookNew.instance.deger = false;
        MouseLookNew.instance.look = false;
    }
    public void Close()
    {
        gameObject.SetActive(false);
    }
    private void OnDisable()
    {
        MouseLookNew.instance.deger = true;
        MouseLookNew.instance.look = true;
    }
}
