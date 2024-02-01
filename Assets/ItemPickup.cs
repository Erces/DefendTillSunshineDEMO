using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class ItemPickup : Interactable
{
    public Item item;
    public bool wasPickedUp;
    public bool pickable = true;
    public GameObject particle;
    public AudioSource source;
    private void Start()
    {
        source = GameObject.Find("ItemPickUp").GetComponent<AudioSource>();
    }
    public void PickUp()
    {
        if (!pickable)
        {
            return;
        }
        Debug.Log("Picking up item.");
        pickable = false;
        wasPickedUp = Inventory.instance.Add(item);
        if (wasPickedUp&&!pickable)
        {
            source.Play();
            
            Invoke("spawnParticle", 1.49f);
            Vector3 target = new Vector3(0, 0.5f, 0);
            Vector3 rotateVector = new Vector3(0, 180, 0);
            Vector3 scale = new Vector3(2, 2, 2);

            transform.DOMove(transform.position + target, 1);
            transform.DORotate(Quaternion.ToEulerAngles(transform.localRotation) + rotateVector, 1).SetLoops(-1, LoopType.Incremental);
            transform.DOScale(transform.localScale*0.3f, 2).SetLoops(-1, LoopType.Yoyo);
            Destroy(gameObject,1.5f);
        }
    }
    private void spawnParticle()
    {
        GameObject partic = Instantiate(particle, transform.position, Quaternion.identity);
        //Destroy(partic, 3);
    }
}
