using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OutlineScript : MonoBehaviour
{
    public GameObject[] interactnot;
    public int UIdeger;

   
    private void OnMouseOver()

    {
        this.gameObject.GetComponent<MeshRenderer>().materials[1].SetFloat("_OutlineWidth", 0.05f);
        interactnot[UIdeger].SetActive(true);
    }
    private void OnMouseExit()
    {
        this.gameObject.GetComponent<MeshRenderer>().materials[1].SetFloat("_OutlineWidth", 0.0f);
        interactnot[UIdeger].SetActive(false);
    }
}
