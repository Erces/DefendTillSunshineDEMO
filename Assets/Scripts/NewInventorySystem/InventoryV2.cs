using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryV2 : MonoBehaviour
{
    private List<ItemStackV2> inventoryContents = new List<ItemStackV2>();

    public InventoryV2(int size)
    {
        for(int i = 0; i < size; i++)
        {
            inventoryContents.Add(new ItemStackV2(i));
        }
    }
    public bool addItem(ItemStackV2 input)
    {
        foreach(ItemStackV2 stack in inventoryContents)
        {
            if (stack.isEmpty())
            {
                stack.setStack(input);
                return true;
            }
            else
            {
                if (ItemStackV2.areItemsEqual(input,stack))
                {
                    if (stack.canAddToo(input.getCount()))
                    {
                        stack.increaseAmount(input.getCount());
                        return true;
                    }
                    else
                    {
                        int difference = (stack.getCount() + input.getCount()) -stack.getItem().maxStackSize;
                        stack.setCount(stack.getItem().maxStackSize);
                        input.setCount(difference);
                    }
                }
            }
        }
        return false;
    }
    public ItemStackV2 getStackInSlot(int index)
    {
        return inventoryContents[index];

    }

    public List<ItemStackV2> getInventoryStacks()
    {
        return inventoryContents;
    }
}
