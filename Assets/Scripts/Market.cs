using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
public class Market : MonoBehaviour
{
    public ItemV2[] Items;
    public MarketSlot[] mSlots;
    public static Market instance;
    public GameObject UI,player;
    public string marketName;
    
    void Start()
    {
        player = GameObject.Find("!MAINCHARACTER");
        if (instance != null)
        {
            Debug.Log("instance error market");
            return;
        }
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs( Vector3.Distance(player.transform.position,this.transform.position)) < 5)
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                getItemPrices();
                UI.SetActive(!UI.activeSelf);
            }
        }
    }
    public void addItem(ItemV2 item,string Description,int count, bool isLimited)
    {
        Debug.Log("adding item to market");
        for (int i = 0; i < mSlots.Length; i++)
        {
            if (!mSlots[i].isFull)
            {
                if (isLimited)
                {
                    mSlots[i].setLimitedUI();
                }
                Debug.Log("ITEM COUNT: " + count);
                mSlots[i].itemImage.sprite = item.ItemIcon;
                mSlots[i].itemInfo.text = item.ItemName;
                mSlots[i].itemName = item.ItemName;
                
                mSlots[i].isFull = true;
                break;
            }
        }
    }
    public void getItemPrices()
    {
        GetCatalogItemsRequest req = new GetCatalogItemsRequest();
        req.CatalogVersion = "Market";

        PlayFabClientAPI.GetCatalogItems(req, result => {
            List<CatalogItem> items = result.Catalog;

            foreach (CatalogItem i in items)
            {
                uint cost = i.VirtualCurrencyPrices["RM"];
                foreach (ItemV2 editorItems in Items)
                {
                    if (editorItems.ItemName == i.DisplayName)
                    {
                        Debug.Log(editorItems.ItemName + " found on market");
                        bool isLimited = i.IsLimitedEdition;
                        Market.instance.addItem(editorItems, i.Description, i.InitialLimitedEditionCount,isLimited) ;
                     
                    }

                }
                Debug.Log(cost);
            }

        }, error => { });
    }
    

}
