using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
   



    public int chestSpace = 10;
    public List<Item> items = new List<Item>();
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void addToChest(Item item)
    {
        items.Add(item);
        Inventory.instance.Remove(item);
    }
}
