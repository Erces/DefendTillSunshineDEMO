using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using PlayFab.ClientModels;
using PlayFab;

public class MarketSlot : MonoBehaviour
{
    public string itemName;
    public int itemCost;
    public Image itemImage;
    public TMP_Text itemInfo;
    public bool isFull;
    public GameObject limitedUI;

    public void MakePurchase()
    {

        PurchaseItemRequest req = new PurchaseItemRequest();
        req.CatalogVersion = "Market";
        req.ItemId = itemName;
        req.VirtualCurrency = "RM";
        req.Price = itemCost;

        PlayFabClientAPI.PurchaseItem(req, result =>
        {
            Debug.Log("purchased");


        }, error =>
        {
            Debug.Log(error.ErrorMessage);
        }

        );
    }

    public void setLimitedUI() { limitedUI.SetActive(true); }
}
