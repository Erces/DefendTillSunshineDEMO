using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Food")]
public class Food : Item
{
    public float hungerRegen;
    public float waterRegen;
    public float healthRegen;

    
    public override void Use()
    {
        if (this.name == "Mushroom" || this.name == "Fish")
        {
            InventorySound.instance.playEatSound();

        }
        if (this.name == "DeerMushroomSoup")
        {
            InventorySound.instance.playDrinkSound();
        }
        base.Use();
        Debug.Log("Overriding");
        GameObject.Find("!MAINCHARACTER").GetComponent<PlayerSituation>().hungerlevel += hungerRegen;
        GameObject.Find("!MAINCHARACTER").GetComponent<PlayerSituation>().waterlevel += waterRegen;

    }
}
