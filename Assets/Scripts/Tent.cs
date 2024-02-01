using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tent : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider slide;
    public GameObject canta;
    
   [SerializeField] private GameObject player;
    void Start()
    {
        player = GameObject.Find("!MAINCHARACTER");
        canta = player.transform.Find("mixamorig:Hips/mixamorig:Spine/tentbag2").gameObject;
        slide.maxValue = 4;
        slide.value = 0;   
    }

    // Update is called once per frame
    void Update()
    {
        if (slide.value == slide.maxValue)
        {

            canta.SetActive(true);
            Destroy(this.gameObject);
            
        }
    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        slide.gameObject.SetActive(true);
    }
    private void OnTriggerStay(Collider col)
    {

        if (col.tag == "Player")
        {
            if (Input.GetKey(KeyCode.E))
            {
                slide.value += 1 * Time.deltaTime;
            }
            if (Input.GetKeyUp(KeyCode.E))
            {
                slide.value = 0;
            }
        }
    }
    private void OnTriggerExit(Collider col)
    {
     if (col.tag == "Player")
        {
            slide.value = 0;
            slide.gameObject.SetActive(false);
        }   
    }
}
