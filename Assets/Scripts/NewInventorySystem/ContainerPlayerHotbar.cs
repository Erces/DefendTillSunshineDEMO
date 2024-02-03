using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerPlayerHotbar : Container
{
   public ContainerPlayerHotbar(InventoryV2 containerInventory, InventoryV2 playerInventory) : base(containerInventory, playerInventory)
    {
        for(int i = 0;i < 6; i++)
        {
            addSlotToContainer(playerInventory, i, -125, 0, 50);
        }
    }
    public override GameObject getContainerPrefab()
    {
        return InventoryManagerV2.INSTANCE.getContainerPrefab("Player Hotbar");
    }
}
