using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject


{
    new public string name = "New Item";
    public Sprite icon;
    public bool isDefaultItem = false;
    public bool usable;
    [Range(1, 100)] public int maxStackSize = 100;


    public virtual void Use()
    {

        Debug.Log("Using " + name);
    }









}
    


