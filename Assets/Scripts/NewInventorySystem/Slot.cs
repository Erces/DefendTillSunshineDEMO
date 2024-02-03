using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Slot : MonoBehaviour, IPointerDownHandler ,IPointerEnterHandler, IPointerExitHandler
{
    public Image itemIcon;
    public Text itemAmount;
    private int slotID;
    private ItemStackV2 myStack;
    private Container attachedContainer;
    private InventoryManagerV2 inventoryManager;

    public void setSlot(InventoryV2 attachedInventory, int slotID, Container attachedContainer)
    {
        this.slotID = slotID;
        this.attachedContainer = attachedContainer;
        myStack = attachedInventory.getStackInSlot(slotID);
        inventoryManager = InventoryManagerV2.INSTANCE;
        updateSlot();
    }

    public void updateSlot()
    {
        if (!myStack.isEmpty())
        {
            itemIcon.enabled = true;
            itemIcon.sprite = myStack.getItem().ItemIcon;

            if (myStack.getCount() > 1)
            {
                itemAmount.text = myStack.getCount().ToString();
            }
            else
            {
                itemAmount.text = string.Empty;
            }
        }
        else
        {
            itemIcon.enabled = false;
            itemAmount.text = string.Empty;
        }
    }

    private void setSlotContents(ItemStackV2 stackIn)
    {
        myStack.setStack(stackIn);
        updateSlot();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        ItemStackV2 curDraggedStack = inventoryManager.getDraggedItemStack();
        ItemStackV2 stackCopy = myStack.copy();

        if (eventData.pointerId == -1)
        {
            onLeftClick(curDraggedStack, stackCopy);
        }

        if (eventData.pointerId == -2)
        {
            onRightClick(curDraggedStack, stackCopy);
        }
    }

    private void setTooltip(string nameIn)
    {
        inventoryManager.drawToolTip(nameIn);
    }

    private void onLeftClick(ItemStackV2 curDraggedStack, ItemStackV2 stackCopy)
    {
        if (!myStack.isEmpty() && curDraggedStack.isEmpty())
        {
            inventoryManager.setDragedItemStack(stackCopy);
            this.setSlotContents(ItemStackV2.Empty);
            setTooltip(string.Empty);
        }

        if (myStack.isEmpty() && !curDraggedStack.isEmpty())
        {
            this.setSlotContents(curDraggedStack);
            inventoryManager.setDragedItemStack(ItemStackV2.Empty);
            setTooltip(myStack.getItem().ItemName);
        }

        if (!myStack.isEmpty() && !curDraggedStack.isEmpty())
        {
            if (ItemStackV2.areItemsEqual(stackCopy, curDraggedStack))
            {
                if (stackCopy.canAddToo(curDraggedStack.getCount()))
                {
                    stackCopy.increaseAmount(curDraggedStack.getCount());
                    this.setSlotContents(stackCopy);
                    inventoryManager.setDragedItemStack(ItemStackV2.Empty);
                    setTooltip(myStack.getItem().ItemName);
                }
                else
                {
                    int difference = (stackCopy.getCount() + curDraggedStack.getCount()) - stackCopy.getItem().maxStackSize;
                    stackCopy.setCount(myStack.getItem().maxStackSize);
                    ItemStackV2 dragCopy = curDraggedStack.copy();
                    dragCopy.setCount(difference);
                    this.setSlotContents(stackCopy);
                    inventoryManager.setDragedItemStack(dragCopy);
                    setTooltip(string.Empty);
                }
            }
            else
            {
                ItemStackV2 curDragCopy = curDraggedStack.copy();
                this.setSlotContents(curDraggedStack);
                inventoryManager.setDragedItemStack(stackCopy);
                setTooltip(string.Empty);
            }
        }
    }

    private void onRightClick(ItemStackV2 curDraggedStack, ItemStackV2 stackCopy)
    {
        if (!myStack.isEmpty() && curDraggedStack.isEmpty())
        {
            ItemStackV2 stack = stackCopy.splitStack((stackCopy.getCount() / 2));
            inventoryManager.setDragedItemStack(stack);
            this.setSlotContents(stackCopy);
            setTooltip(string.Empty);

        }

        if (myStack.isEmpty() && !curDraggedStack.isEmpty())
        {
            this.setSlotContents(new ItemStackV2(curDraggedStack.getItem(), 1));
            ItemStackV2 curDragCopy = curDraggedStack.copy();
            curDragCopy.decreaseAmount(1);
            inventoryManager.setDragedItemStack(curDragCopy);
            setTooltip(string.Empty);

        }

        if (!myStack.isEmpty() && !curDraggedStack.isEmpty())
        {
            if (ItemStackV2.areItemsEqual(stackCopy, curDraggedStack))
            {
                if (myStack.canAddToo(1))
                {
                    stackCopy.increaseAmount(1);
                    this.setSlotContents(stackCopy);
                    ItemStackV2 dragCopy = curDraggedStack.copy();
                    dragCopy.decreaseAmount(1);
                    inventoryManager.setDragedItemStack(dragCopy);
                    setTooltip(string.Empty);

                }
            }
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        ItemStackV2 curDraggedStack = inventoryManager.getDraggedItemStack();
        ItemStackV2 copiedStack = myStack.copy();

        if (!myStack.isEmpty() && curDraggedStack.isEmpty())
        {
            setTooltip(myStack.getItem().ItemName);
            //inventoryManager.drawToolTip(myStack.getItem().ItemName);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        setTooltip(string.Empty);

       // inventoryManager.drawToolTip(string.Empty);

    }
}