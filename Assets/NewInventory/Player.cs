using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public ItemV2[] itemsToAdd;

    private InventoryV2 myInventory = new InventoryV2(24);
   
    private bool isOpen;

    private void Start()
    {
        foreach (ItemV2 item in itemsToAdd)
        {
            myInventory.addItem(new ItemStackV2(item, 1));
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!InventoryManagerV2.INSTANCE.hasInventoryCurrentlyOpen())
            {
                InventoryManagerV2.INSTANCE.openContainer(new ContainerPlayerInventory(null, myInventory));
                

                isOpen = true;
            }
            else
            {
                InventoryManagerV2.INSTANCE.openContainer(new ContainerPlayerHotbar(null, myInventory));
                isOpen = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isOpen)
            {
                InventoryManagerV2.INSTANCE.openContainer(new ContainerPlayerHotbar(null, myInventory));
                isOpen = false;
            }
        }
       
    }
    public InventoryV2 getInventory()
    {
        return myInventory;
    }
}