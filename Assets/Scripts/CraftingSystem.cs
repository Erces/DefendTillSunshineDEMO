using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingSystem : MonoBehaviour
{
    Inventory inventory;
    [Header("Crafable Items")]
    public Item fishsoup,wall;
    [Header("Counts")]
    public int fishcount;
    

    void Start()
    {
        inventory = Inventory.instance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void craftSoup()
    {
        
        Debug.Log(inventory.items.Count);
        Debug.Log("Trying to craft");
        fishcount = 0;
        for (int i = 0;i < 2; i++)
        {
            if (fishcount == 2)
            {
                inventory.Add(fishsoup);
                Debug.Log("Crafting soup");
                break;
            }
            if (inventory.items[i].name == "Fish")
            {
                inventory.Remove(inventory.items[i]);
                fishcount++;               
                i--;
                
            }
               
      
        }
        
    }
    public void craftWall()
    {
        inventory.Add(wall);
    }
}
