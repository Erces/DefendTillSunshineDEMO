using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAround : MonoBehaviour
{
    public GameObject normalCamera, LookAroundCamera;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
            normalCamera.SetActive(false);
            LookAroundCamera.SetActive(true);

        }
        if (Input.GetKeyUp(KeyCode.LeftAlt))
        {
            normalCamera.SetActive(true);
            LookAroundCamera.SetActive(false);

        }
    }
}
