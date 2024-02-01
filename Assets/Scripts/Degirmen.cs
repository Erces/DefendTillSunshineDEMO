using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Degirmen : MonoBehaviour
{
    public Transform degirmen;
    public float rotatespeed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        degirmen.Rotate(rotatespeed * Time.deltaTime, 0, 0);
    }
}
