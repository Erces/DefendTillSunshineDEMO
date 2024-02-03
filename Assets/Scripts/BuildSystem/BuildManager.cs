using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BuildManager : MonoBehaviour
{
    public GameObject foundation;
    public GameObject wall;
    public GameObject door;
    public GameObject stairs,window,attic;
    public List<Item> items;

    public Image circle;

    public BuildSystem buildSystem;
    public static BuildManager instance;
    // Update is called once per frame
    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log ("There is already a build manager!");
            return;
        }
        instance = this;

    }
    void Update()
    {
        

    }
    public void Build(GameObject buildable)
    {
        buildSystem.NewBuild(buildable);
    }
    public void buildFountain()
    {
        int count = 0;
        foreach (var item in Inventory.instance.items)
        {

            if (item.name == "Log")
            {
                items.Add(item);
                Debug.Log("logcount");
                count++;
                //Inventory.instance.items.Remove(item);
            }
            if (count >= 2)
            {
                Inventory.instance.items.Remove(items[0]);
                Inventory.instance.items.Remove(items[0]);
                buildSystem.NewBuild(foundation);
                break;
            }
            else
            {
                //Not enough wood
            }

        }
        

    }
    public void buildWall()
    {
        int count = 0;
        foreach (var item in Inventory.instance.items)
        {

            if (item.name == "Log")
            {
                items.Add(item);
                Debug.Log("logcount");
                count++;
                //Inventory.instance.items.Remove(item);
            }
            if (count >= 2)
            {
                Inventory.instance.items.Remove(items[0]);
                Inventory.instance.items.Remove(items[0]);
                buildSystem.NewBuild(wall);
                break;
            }
            else
            {
                //Not enough wood
            }

        }


    }
    public void buildWindow()
    {
        int count = 0;
        foreach (var item in Inventory.instance.items)
        {

            if (item.name == "Log")
            {
                items.Add(item);
                Debug.Log("logcount");
                count++;
                //Inventory.instance.items.Remove(item);
            }
            if (count >= 2)
            {
                Inventory.instance.items.Remove(items[0]);
                Inventory.instance.items.Remove(items[0]);
                buildSystem.NewBuild(window);
                break;
            }
            else
            {
                //Not enough wood
            }

        }


    }
    public void buildAttic()
    {
        int count = 0;
        foreach (var item in Inventory.instance.items)
        {

            if (item.name == "Log")
            {
                items.Add(item);
                Debug.Log("logcount");
                count++;
                //Inventory.instance.items.Remove(item);
            }
            if (count >= 2)
            {
                Inventory.instance.items.Remove(items[0]);
                Inventory.instance.items.Remove(items[0]);
                buildSystem.NewBuild(attic);
                break;
            }
            else
            {
                //Not enough wood
            }

        }


    }
    public void buildDoor()
    {
        int count = 0;
        foreach (var item in Inventory.instance.items)
        {

            if (item.name == "Log")
            {
                items.Add(item);
                Debug.Log("logcount");
                count++;
                //Inventory.instance.items.Remove(item);
            }
            if (count >= 2)
            {
                Inventory.instance.items.Remove(items[0]);
                Inventory.instance.items.Remove(items[0]);
                buildSystem.NewBuild(door);
                Debug.Log("Building door!");
                break;
            }
            else
            {
                //Not enough wood
            }

        }


    }

}
