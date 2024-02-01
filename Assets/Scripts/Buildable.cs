using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Buildable")]
public class Buildable : Item
{
    public GameObject whatWillSpawn;
    
    public override void Use()
    {
        base.Use();
        Debug.Log("Overriding");
        BuildManager.instance.Build(whatWillSpawn);
        
        MouseLook.instance.look = true;
        Screen.lockCursor = true;
    }
}
