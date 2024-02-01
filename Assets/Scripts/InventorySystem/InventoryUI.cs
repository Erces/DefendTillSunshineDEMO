using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public Text text;
    private bool invtoggle = false;
    public GameObject inv;
    Inventory inventory;
    public Transform itemsParent;
    public GameObject[] slotswooden;
    InventorySlot[] slots;
    private AudioSource source;
    public AudioClip clip;
    void Start()
    {
        source = GetComponent<AudioSource>();
        inventory = Inventory.instance;
        inventory.onItemChangedCallback += UpdateUI;
        
        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            MouseLookNew.instance.deger = inv.activeSelf;
            MouseLookNew.instance.look = inv.activeSelf;
            source.PlayOneShot(clip);
            
            inv.SetActive(!inv.activeSelf);
            
            foreach (var slot in slotswooden)
            {
                slot.SetActive(!slot.activeSelf);
            }
            UpdateUI();
        }

    }
    void UpdateUI()
    {
        Debug.Log("Updating UI;");
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < inventory.items.Count)
            {
                slots[i].AddItem(inventory.items[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }
    public void pickUpUI(Item item)
    {
        text.text = (item.name + " added to your bag"  );
        Invoke("clearPickUpUI", 2f);
    }
    void clearPickUpUI()
    {
        text.text = string.Empty;
    }
}
