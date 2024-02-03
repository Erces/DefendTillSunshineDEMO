using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class Fishing : MonoBehaviour
{
    public delegate void CatchFish();
    public static event CatchFish onCatchFish;

    public GameObject gun;
    public GameObject riggun;
    public GameObject rigfish;
    public GameObject fishingrod;
    PlayerMovement movement;
    private Animator animator;
    public InventoryUI invui;
    public Item fish;
    private bool isFishingNow = false;
    public float fishtime= 10;
    public bool timeset = false;
    private void OnEnable()
    {
        PlayerMovement.onFishingStart += BalikTutmaBaslama;
    }
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
       
    }

    // Update is called once per frame
    void Update()
    {
        if (isFishingNow)
        {
            riggun.GetComponent<Rig>().weight = 0;
            rigfish.GetComponent<Rig>().weight = 1;
            fishingrod.SetActive(true);
            gun.SetActive(false);
            fishtime -= Time.deltaTime;
            if (Input.GetMouseButtonUp(0) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
            {
                gun.SetActive(true);
                rigfish.GetComponent<Rig>().weight = 0;
                riggun.GetComponent<Rig>().weight = 1;
                fishingrod.SetActive(false);
                isFishingNow = false;
                animator.SetTrigger("FishEnd");
            }
            if (fishtime <= 0)
            {
                onCatchFish?.Invoke();
                gun.SetActive(true);
                rigfish.GetComponent<Rig>().weight = 0;
                riggun.GetComponent<Rig>().weight = 1;
                fishingrod.SetActive(false);
                isFishingNow = false;
                Inventory.instance.Add(fish);
                invui.pickUpUI(fish);
                Debug.Log("Balik tutuldu!");
                animator.SetTrigger("FishEnd");
                fishtime = Random.Range(10,30);
            }
        }
    }
    public void BalikTutmaBaslama()
    {
        isFishingNow = true;

        animator.SetTrigger("FishStart");
        
    }

    private void OnDisable()
    {
        PlayerMovement.onFishingStart -= BalikTutmaBaslama;
    }
}
