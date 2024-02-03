using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetUI : MonoBehaviour
{
    public GameObject petUI;
    private bool isOpen;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            petUI.SetActive(!petUI.activeSelf);
            isOpen = !isOpen;
           
            MouseLookNew.instance.deger = !isOpen;
            MouseLookNew.instance.look = !isOpen;
        }
    }
}
