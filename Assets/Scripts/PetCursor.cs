using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetCursor : MonoBehaviour
{
    public LayerMask ground;
    private GameObject cursor;

    public GameObject placeObject;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moveCursor();
        if (cursor != null)
        {
            MoveObject();
        }
    }

    private void MoveObject()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hitInfo;

        if ( Physics.Raycast(ray,out hitInfo,15,ground))
        {
            cursor.transform.position = hitInfo.point;
            cursor.transform.rotation = Quaternion.FromToRotation(Vector3.up, hitInfo.normal);

        }


    }

    void moveCursor()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if ( cursor == null)
            {
                cursor = Instantiate(placeObject);
            }
            
        }
        if (Input.GetKeyUp(KeyCode.F))
        {
            if ( cursor != null)
            {
                Destroy(cursor);
            }
        }
    }
}

