using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton

    public static Inventory instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of inventory found!");
            return;
        }
        instance = this;
    }
    #endregion

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    public InventoryUI invui;


    public int space = 9;
    public List<Item> items = new List<Item>();



    public bool Add(Item item)
    {
        if (!item.isDefaultItem)
        {
            if (items.Count >= space)
            {
                Debug.Log("Not enough room");
                return false;
            }
            Debug.Log("debug");
            items.Add(item);
            invui.pickUpUI(item);
            onItemChangedCallback?.Invoke();
            return true;
            
        }
        return true;

    }
    public void Remove(Item item)
    {
       
        items.Remove(item);
        Debug.Log("Removed" + item.name);
        onItemChangedCallback?.Invoke();

    }
}
