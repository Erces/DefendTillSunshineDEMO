using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OyuncuPrefs : MonoBehaviour
{
    [SerializeField] private float money = 0f;
    public int Rock = 0;
    public int Wood = 0;
    public int Water = 0;
    public int Food = 0;

    public Text txt;
    public Text txtrock;

    public Text txtwood;
    public Text txtfood;
    public Text txtwater;

    void Start()
    {

        updateUI();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay(Collider col)
    {

        
        if (Input.GetKeyDown(KeyCode.E))
        {
            //ItemPick item = col.GetComponent<ItemPick>();
         //   if (item != null)
            {
         //       item.pickUp();
            }
        }

    }
    public void useRock()
    {

        if (Rock > 0)
        {
            Rock--;
        }

    }
    public void useWater()
    {
        if (Water > 0)
        {
            Water--;
        }

    }
    public void useFood()
    {
        if (Food > 0)
        {
            Food--;
        }

    }
    public void useWood()
    {
        if (Wood > 0)
        {
            Wood--;
        }

    }
    private void updateUI()
    {

       
        txtwater.text = Water.ToString("0");
        txtfood.text = Food.ToString("0");
        txtwood.text = Wood.ToString("0");
        txtrock.text = Rock.ToString("0");
    }


}
