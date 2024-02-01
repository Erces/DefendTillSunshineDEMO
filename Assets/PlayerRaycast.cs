using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerRaycast : MonoBehaviour
{
    public CinemachineBrain brain;
    public LayerMask door,window,bed,kazan,interactable,bear;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = brain.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 3f, door) && Input.GetMouseButtonDown(0))
        {
            Debug.Log("KAPI!");
            hit.transform.gameObject.GetComponent<DoorOpen>().triggerDoor();
        }
        if (Physics.Raycast(ray, out hit, 3f, window) && Input.GetMouseButtonDown(0))
        {
            Debug.Log("PENCERE!");
            hit.transform.gameObject.GetComponent<Window>().triggerWindow();
        }
        if (Physics.Raycast(ray, out hit, 3f, bed) && Input.GetMouseButtonDown(0))
        {
            Debug.Log("PENCERE!");
            hit.transform.gameObject.GetComponent<Bed>().BedWork();
        }
        if (Physics.Raycast(ray, out hit, 3f, kazan) && Input.GetMouseButtonDown(0))
        {
            Debug.Log("PENCERE!");
            hit.transform.gameObject.GetComponent<Kazan>().KazanWork();
        }
        if (Physics.Raycast(ray, out hit, 7f, bear) && Input.GetMouseButtonDown(0))
        {
            Debug.Log("bear!");
            
        }

    }
}
