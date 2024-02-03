using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Ring", menuName = "RingMenu/Element", order = 2)]
public class RingElement : ScriptableObject
{
    public string Name;
    public Sprite Icon;
    public Ring nextRing;
}
