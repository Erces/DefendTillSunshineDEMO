using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DraggedItemStack : MonoBehaviour
{
    public Image itemIcon;
    public Text itemAmount;

    private ItemStackV2 myStack = ItemStackV2.Empty;

    public void setDraggedStack(ItemStackV2 stackIn)
    {
        myStack = stackIn;
    }

    private void drawStack()
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
            disableDragStack();
        }
    }

    private void disableDragStack()
    {
        itemIcon.enabled = false;
        itemAmount.text = string.Empty;
    }

    private void Update()
    {
        drawStack();
        transform.position = Input.mousePosition;
    }
}