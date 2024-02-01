using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Item")]
public class ItemV2 : ScriptableObject

{
    public string ItemName;
    public Sprite ItemIcon;
    public int Cost;
    [Range(1, 100)] public int maxStackSize = 100;
}
