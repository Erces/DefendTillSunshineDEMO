using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.UI;

public class Zoom : MonoBehaviour
{
   
    public CinemachineVirtualCamera cam;
    public GameObject scopecanvas;
    public GameObject scopeui;
    public bool deger = false;
    void Start()
    {
        cam = this.GetComponent<CinemachineVirtualCamera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            deger = true;
            
            scopecanvas.SetActive(deger);
            scopeui.SetActive(deger);
            cam.m_Priority = 9;
        }
        if (Input.GetMouseButtonUp(1))
        {
            deger = false;
            
            scopecanvas.SetActive(deger);
            scopeui.SetActive(deger);
            cam.m_Priority = 11;
        }
    }
}
