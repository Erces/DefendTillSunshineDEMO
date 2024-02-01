using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Workbench : MonoBehaviour
{
    public GameObject craftlist;
    private bool situation = false;
    void Start()
    {
        situation = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Work()
    {
        situation = !situation;
        craftlist.SetActive(situation);
        Screen.lockCursor = !situation;
    }
}
