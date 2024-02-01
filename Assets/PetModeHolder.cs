using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class PetModeHolder : MonoBehaviour
{
    public Button auto, manual;
    public TMP_Text text1,text2;

    void Start()
    {
        auto.onClick.AddListener(autoClick);
        manual.onClick.AddListener(manualClick);

        manualClick();

    }

    // Update is called once per frame
    void Update()
    {
       
    }
    void autoClick()
    {
        text1.color = Color.white;
        text2.color = Color.gray;
       // Pet.instance.currentManualState = Pet.ManualState.Automatic;
    }
    void manualClick()
    {
        text1.color = Color.gray;
        text2.color = Color.white;
       // Pet.instance.currentManualState = Pet.ManualState.Manual;


    }
}
