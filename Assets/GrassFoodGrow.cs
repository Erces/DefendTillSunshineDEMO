using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GrassFoodGrow : MonoBehaviour
{
    public TMP_Text txt;
    private int daycount = 0;
    private int growthrate = 0;
    private bool isGrowed;
    void Start()
    {
        DayNightCycle.onDayPass += Grow;
 
    }

    // Update is called once per frame
    void Update()
    {
        if (isGrowed == true)
        {
            gameObject.GetComponent<ItemPickup>().pickable = true;
            isGrowed = false;
        }
    }
    void Grow()
    {
        daycount++;
        growthrate++;
        if (growthrate >=5)
        {
            isGrowed = true;
            return;
        }

        if (daycount == 2)
        {
            gameObject.transform.localScale = (new Vector3(transform.localScale.x * 2f, transform.localScale.y * 2f, transform.localScale.z * 2f));
            daycount = 0;
        }
    }
    private void OnMouseOver()
    {
        txt.gameObject.SetActive(true);
        txt.text = "Growth rate is %" + growthrate * 20;

    }
    private void OnMouseExit()
    {
        txt.gameObject.SetActive(false);
    }

}
