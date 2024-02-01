using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Preview : MonoBehaviour
{
    public GameObject prefab;

    private MeshRenderer myRend;
    public Material goodmat;
    public Material badmat;
    public float deleteRange;
    private bool onObject;

    public BuildSystem buildSystem;
    [SerializeField] private Transform konum;
    private bool isSnapped = false;
    public bool isFoundation = false;

    public List<string> tagsISnapTo = new List<string>();
    void Start()
    {
        konum = this.GetComponent<Transform>();
        buildSystem = GameObject.FindObjectOfType<BuildSystem>();
        myRend = GetComponent<MeshRenderer>();
        ChangeColor();

    }
    public void Place()
    {
        BuildSound.instance.playSound();
        Debug.Log("Placing..");
        Instantiate(prefab, transform.position, transform.rotation);
        Destroy(gameObject);
        Collider[] trash = Physics.OverlapSphere(transform.position, deleteRange);
        Debug.Log(trash);
        foreach(var trashobjects in trash)
        {
            Debug.Log(trashobjects.name);
            if (trashobjects.transform.tag == "trash")
            {
                Destroy(trashobjects.gameObject);
            }
        }
        prefab.GetComponent<SaveableEntity>().GenerateId();
        

    }
    public void ChangeColor()
    {
        if (isSnapped)
        {
            myRend.material = goodmat;
        }
        else
        {
            myRend.material = badmat;
        }
        if (isFoundation)
        {
            myRend.material = goodmat;
            isSnapped = true;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        for (int i = 0; i < tagsISnapTo.Count; i++)
        {
            string currentTag = tagsISnapTo[i];

            if (other.tag == currentTag && !onObject)
            {
                onObject = true;
                Debug.Log("issnapped");
                buildSystem.PauseBuild(true);
                transform.position = other.transform.position;
                isSnapped = true;
                ChangeColor();
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        for (int i = 0; i < tagsISnapTo.Count; i++)
        {
            string currentTag = tagsISnapTo[i];

            if (other.tag == currentTag && onObject)
            {
                onObject = false;
                Debug.Log("not snapped");

                isSnapped = false;
                ChangeColor();
            }
        }
        
    }
    public bool GetSnapped()
    {


        return isSnapped;
    }

  
    
}
