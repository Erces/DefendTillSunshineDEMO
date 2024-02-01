using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportLocation : MonoBehaviour
{
    public GameObject player,dog,txt,cube;
    public Transform playerTransform, dogTransform;
    public int neededDistance = 5;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && txt.activeSelf)
        {
            Debug.Log("EEEE");
            player.transform.root.position = playerTransform.position;
            dog.transform.position = dogTransform.position;
        }
    }
    private void OnMouseOver()
    {
        if (Vector3.Distance(player.transform.position, cube.transform.position) < neededDistance)
        {
            txt.SetActive(true);
        }
    }
     private void OnMouseExit()
    {
        txt.SetActive(false);
    }
}
