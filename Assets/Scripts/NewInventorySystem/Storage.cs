using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Storage : MonoBehaviour
{
    private Player player;
    private InventoryManagerV2 inventoryManager;
    private InventoryV2 inventory = new InventoryV2(27);
    void Start()
    {
        player = FindObjectOfType<Player>();
        inventoryManager = InventoryManagerV2.INSTANCE;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseOver()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);
        if (distance < 2 && !InventoryManagerV2.INSTANCE.hasInventoryCurrentlyOpen())
        {
            if (Input.GetMouseButtonDown(1))
            {
                Debug.Log("Opening chest");
                InventoryManagerV2.INSTANCE.openContainer(new Container(inventory, player.getInventory()));
            }
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("Opening chest");
            InventoryManagerV2.INSTANCE.openContainer(new Container(inventory, player.getInventory()));
        }
    }
}
