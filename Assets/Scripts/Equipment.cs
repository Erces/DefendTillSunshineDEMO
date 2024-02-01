using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;
using System;
using System.Text;

public class Equipment : MonoBehaviour
{
    public enum EquipState { Idle, Gun, Bow, Hatchet }
    public EquipState currentState = EquipState.Idle;
    public GameObject gun, bow, hatchet;
    public GameObject riggun, righatchet;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //1 freehand 2 gun 3 bow 4 hatchet

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentState = EquipState.Gun;
            switchEquipments(currentState);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            currentState = EquipState.Bow;
            switchEquipments(currentState);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            currentState = EquipState.Hatchet;
            switchEquipments(currentState);
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentState = EquipState.Idle;
            switchEquipments(currentState);
        }
    }
    void switchEquipments(EquipState _currentstate)
    {
        righatchet.GetComponent<Rig>().weight = Convert.ToInt32(_currentstate == EquipState.Hatchet);
        riggun.GetComponent<Rig>().weight = Convert.ToInt32(_currentstate == EquipState.Gun);
        

        bow.SetActive(_currentstate == EquipState.Bow);
        gun.SetActive(_currentstate == EquipState.Gun);
        hatchet.SetActive(_currentstate == EquipState.Hatchet);
    }
}
