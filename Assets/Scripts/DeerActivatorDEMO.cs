using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeerActivatorDEMO : MonoBehaviour
{
    public GameObject[] deers;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            foreach (var item in deers)
            {
                item.SetActive(true);
            }
            Destroy(gameObject);
        }
    }
}
