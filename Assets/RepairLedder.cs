using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using DG.Tweening;

public class RepairLedder : MonoBehaviour
{
    public Quest quest;
    public MeshRenderer mrender;
    public CinemachineBrain brain;
    public LayerMask ladder;
    public Material material;
    public Color color;
    public int count = 0;
    public List<Item> items;
    public GameObject UI;
    void Start()
    {
        DOTween.Init();
        mrender = GetComponent<MeshRenderer>();
        
        color = material.color;
        Debug.Log(Inventory.instance.items.Count);
    }

    // Update is called once per frame
    void Update()
    {
        if (quest.isDone)
        {
            
            Ray ray = brain.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 5f, ladder) && Input.GetMouseButtonDown(0))
            {

                Debug.Log("ladder");
                
                count = 0;
                foreach (var item in Inventory.instance.items)
                {
                    Debug.Log("Count: " + count);
                    Debug.Log(item.name);
                    if (item.name == "Log")
                    {
                        Debug.Log("Hazariyeeeeeee");
                        items.Add(item);
                        count++;
                        Debug.Log("Hazariyeee");
                    }
                    if (count == 1)
                    {
                        Inventory.instance.items.Remove(items[0]);
                        BuildSound.instance.playSound();
                        Debug.Log("Ladder!");
                        mrender.material = material;
                        transform.DOScale(transform.localScale * 1.1f, 0.2f).SetLoops(2, LoopType.Yoyo);
                        GetComponent<BoxCollider>().isTrigger = false;
                        Destroy(this);
                       
                    }

                }
            }
        }
    }
    private void OnMouseOver()
    {
        UI.SetActive(true);
    }
    private void OnMouseExit()
    {
        UI.SetActive(false);   
    }

}
