using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CircleSlider : MonoBehaviour
{
    public Image circle;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void circleFill()
    {
        if (circle.fillAmount >= 1)
        {
            
            circle.fillAmount = 0;
           
        }
        if (Input.GetKey(KeyCode.B))
        {
            circle.fillAmount += 0.1f * Time.deltaTime;
           
        }
            
        
        
    }
}
