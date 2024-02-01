using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float sens = 1000f;
    public Transform playerbody;
    public GameObject cam;
    public GameObject player;
    public bool look = true;
    public bool deger = true;
    public static MouseLook instance;
    float xRotation = 0f;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("Warning! mouselook scripts");
            return;
        }
        instance = this;

    }
    void Start()
    {
        look = true;
        Screen.lockCursor = true;
    }

    // Update is called once per frame
    void Update()
    {
        Screen.lockCursor = deger;

        if (Input.GetKeyDown(KeyCode.B) || Input.GetKeyDown(KeyCode.I) || Input.GetKeyDown(KeyCode.Q)   )
         {
           deger = !deger;
           Screen.lockCursor = deger;
        look = deger;

         }


        if (look)
        {
            camlook();
        }

    }
    void camlook()
    {
       float mouseX = Input.GetAxis("Mouse X") * sens * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sens * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -50f, 50f);
      transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        playerbody.Rotate(Vector3.up * mouseX);
    }
}
