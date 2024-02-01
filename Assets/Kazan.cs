using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kazan : MonoBehaviour
{
    public GameObject player,ui,not;
    public GameObject[] others;
    public Item dmsoup;
    public float neededDistance = 5;
    private int countmushroom,countmeat;
    public List<Item> items;

    public void KazanWork()
    {
        Debug.Log("Kazan!");
            if (Vector3.Distance(player.transform.position, this.transform.position) < neededDistance)
            {
                ui.SetActive(true);
            
        }
        foreach (var item in others)
        {
            item.SetActive(false);
        }
        
    }
    public void DeerMushroomSoup()
    {
        countmeat = 0;
        countmushroom = 0;
        foreach (var item in Inventory.instance.items)
        {
            Debug.Log("Count: " + countmeat);
            Debug.Log(item.name);
            if (item.name == "Beef" && countmeat < 1)
            {
               
                items.Add(item);
                countmeat++;
               
            }
            else if (item.name == "Mushroom" && countmushroom < 1)
            {
                items.Add(item);
                countmushroom++;
            }
            if (countmeat >= 1 && countmushroom >= 1)
            {
                Inventory.instance.items.Remove(items[0]);
                Inventory.instance.items.Remove(items[1]);
               
                Debug.Log("Soup!");
                Inventory.instance.items.Add(dmsoup);


                not.SetActive(true);
                Invoke("NotDisable", 2f);

            }

        }
    }
    public void NotDisable()
    {
        not.SetActive(false);
    }

  
}
