using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.EventSystems;

public class Sensitivy : MonoBehaviour
{
    public CinemachineFreeLook freelokcam;
    void Start()
    {
        if (!PlayerPrefs.HasKey("Sens"))
        {
            PlayerPrefs.SetFloat("Sens", 300);
        }
        freelokcam = GetComponent<CinemachineFreeLook>();
        freelokcam.m_XAxis.m_MaxSpeed = 300;
    }

    // Update is called once per frame
    void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            freelokcam.m_XAxis.m_MaxSpeed = 0;
            freelokcam.m_YAxis.m_MaxSpeed = 0;
        }
        else if (!EventSystem.current.IsPointerOverGameObject())
        {
            freelokcam.m_XAxis.m_MaxSpeed = PlayerPrefs.GetFloat("Sens");
            freelokcam.m_YAxis.m_MaxSpeed = 2;
        }
    }
}
