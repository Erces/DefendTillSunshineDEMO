using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManagerV2 : MonoBehaviour
{
    #region Singleton
    public static InventoryManagerV2 INSTANCE;

    private void Awake()
    {
        INSTANCE = this;
    }
    #endregion

    public GameObject slotPrefab;
    public List<ContainerGetter> containers = new List<ContainerGetter>();
    private Container currentOpenContainer;
    private ItemStackV2 curDraggedStack = ItemStackV2.Empty;
    private GameObject spawnedDragStack;
    private DraggedItemStack dragStack;
    private Tooltip tooltip;
    private Player player;
    private bool hasInventoryOpen = false;

    private void Start()
    {
        dragStack = GetComponentInChildren<DraggedItemStack>();
        tooltip = GetComponentInChildren<Tooltip>();
        player = FindObjectOfType<Player>();
    }
    private void Update()
    {
        if (hasInventoryOpen)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                openContainer(new ContainerPlayerHotbar(null, player.getInventory()));
                hasInventoryOpen = false;
            }
        }
    }
    public bool hasInventoryCurrentlyOpen()
    {
        return hasInventoryOpen;
    }
    public GameObject getContainerPrefab(string name)
    {
        foreach (ContainerGetter container in containers)
        {
            if (container.containerName == name)
            {
                return container.containerPrefab;
            }
        }

        return null;
    }

    public void openContainer(Container container)
    {
        if (currentOpenContainer != null)
        {
            currentOpenContainer.closeContainer();
        }

        currentOpenContainer = container;

        hasInventoryOpen = true;
    }

    public void closeContainer()
    {
        if (currentOpenContainer != null)
        {
            currentOpenContainer.closeContainer();
        }

        hasInventoryOpen = false;
    }

    public ItemStackV2 getDraggedItemStack()
    {
        return curDraggedStack;
    }

    public void setDragedItemStack(ItemStackV2 stackIn)
    {
        dragStack.setDraggedStack(curDraggedStack = stackIn);
    }

    public void drawToolTip(string itemName)
    {
        tooltip.setTooltip(itemName);
    }
}

[System.Serializable]
public class ContainerGetter
{
    public string containerName;
    public GameObject containerPrefab;
}