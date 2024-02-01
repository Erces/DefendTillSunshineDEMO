using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemStackV2
{
    public static ItemStackV2 Empty = new ItemStackV2();
    public ItemV2 item;
    public int count;
    public int slotID;

    public ItemStackV2()
    {
        this.item = null;
        this.count = 0;
        this.slotID = -1;
    }

    public ItemStackV2(int slotID)
    {
        this.item = null;
        this.count = 0;
        this.slotID = slotID;
    }

    public ItemStackV2(ItemV2 item, int count)
    {
        this.item = item;
        this.count = count;
        this.slotID = -1;
    }

    public ItemStackV2(ItemV2 item, int count, int slotID)
    {
        this.item = item;
        this.count = count;
        this.slotID = slotID;
    }

    public ItemV2 getItem()
    {
        return this.item;
    }

    public int getCount()
    {
        return this.count;
    }

    public void setStack(ItemStackV2 stackIn)
    {
        this.item = stackIn.getItem();
        this.count = stackIn.getCount();
    }

    public bool isEmpty()
    {
        return this.count < 1;
    }

    public void increaseAmount(int amount)
    {
        this.count += amount;
    }

    public void decreaseAmount(int amount)
    {
        this.count -= amount;
    }

    public void setCount(int amount)
    {
        this.count = amount;
    }

    public bool canAddToo(int amount)
    {
        return (this.count + amount) <= this.item.maxStackSize;
    }

    public ItemStackV2 splitStack(int amount)
    {
        int i = Mathf.Min(amount, count);
        ItemStackV2 copiedStack = this.copy();
        copiedStack.setCount(i);
        this.decreaseAmount(i);
        return copiedStack;
    }

    public ItemStackV2 copy()
    {
        return new ItemStackV2(this.item, this.count, this.slotID);
    }

    public bool isItemEqual(ItemStackV2 stackIn)
    {
        return !stackIn.isEmpty() && this.item == stackIn.getItem();
    }

    public static bool areItemsEqual(ItemStackV2 stackA, ItemStackV2 stackB)
    {
        return stackA == stackB ? true : (!stackA.isEmpty() && !stackB.isEmpty() ? stackA.isItemEqual(stackB) : false);
    }
}