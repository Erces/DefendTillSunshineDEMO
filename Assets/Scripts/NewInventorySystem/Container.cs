using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Container
{
    private List<Slot> slots = new List<Slot>();
    private GameObject spawnedContainerPrefab;
    private InventoryV2 containerInventory;
    private InventoryV2 playerInventory;

    public Container(InventoryV2 containerInventory, InventoryV2 playerInventory)
    {
        this.containerInventory = containerInventory;
        this.playerInventory = playerInventory;
        openContainer();
    }

    public void addSlotToContainer(InventoryV2 inventory, int slotID, float x, float y, int slotSize)
    {
        GameObject spawnedSlot = Object.Instantiate(InventoryManagerV2.INSTANCE.slotPrefab);
        Slot slot = spawnedSlot.GetComponent<Slot>();
        RectTransform slotRT = slot.GetComponent<RectTransform>();
        slot.setSlot(inventory, slotID, this);
        spawnedSlot.transform.SetParent(spawnedContainerPrefab.transform);
        spawnedSlot.transform.SetAsLastSibling();
       // slotRT.anchoredPosition = new Vector2(x, y);
       // slotRT.sizeDelta = Vector2.one * slotSize;
       // slotRT.localScale = Vector3.one ;
        slots.Add(slot);
    }
    public void updateSlots()
    {
        foreach (Slot slot in slots)
        {
            slot.updateSlot();
        }
    }

    public void openContainer()
    {
        spawnedContainerPrefab = Object.Instantiate(getContainerPrefab(), InventoryManagerV2.INSTANCE.transform);
        spawnedContainerPrefab.transform.SetAsFirstSibling();
    }

    public void closeContainer()
    {
        Object.Destroy(spawnedContainerPrefab);
    }

    //Needs to be overriden can not be left blank or null
    public virtual GameObject getContainerPrefab()
    {
        return null;
    }

    public GameObject getSpawnedContainer()
    {
        return spawnedContainerPrefab;
    }

    public InventoryV2  getContainerInventory()
    {
        return containerInventory;
    }

    public InventoryV2 getPlayerInventory()
    {
        return playerInventory;
    }
}