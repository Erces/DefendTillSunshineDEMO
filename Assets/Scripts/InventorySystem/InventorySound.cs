using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySound : MonoBehaviour
{
    public static InventorySound instance;
    public AudioSource source;
    public AudioClip clipeat,clipsoup;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("Error inventorysound");
            return;
        }
        instance = this;
    }
  public  void playEatSound()
    {
        source.PlayOneShot(clipeat);
    }
    public void playDrinkSound()
    {
        source.PlayOneShot(clipsoup);
    }
}
