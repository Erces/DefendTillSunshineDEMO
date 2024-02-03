using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseLookNew : MonoBehaviour
{
    public static MouseLookNew instance;
    public bool look = true;
    public bool deger = true;
    void Start()
    {
        if (instance != null)
        {
            Debug.Log("Error mouselooknew");
            return;
        }
        instance = this;
        look = true;
        Screen.lockCursor = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        Screen.lockCursor = deger;
    }
}
