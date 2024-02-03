using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
public class RingTween : MonoBehaviour
{
    public GameObject petring, buildring,mainrig;
    public Button firstbutton, secondbutton;
    public bool abilityRing;
    public void mainRingDown()
    {
        mainrig.transform.DOScale(transform.localScale * 0.5f, 0.3f);
    }
    public void mainRingUp()
    {
        mainrig.transform.DOScale(transform.localScale * 2f, 0.3f);
    }
    public void openPetRing()
    {
        firstbutton.interactable = false;
        secondbutton.interactable = false;
        petring.SetActive(true);
        petring.transform.DOScale(transform.localScale * 1f, 0.3f);
    }
    public void openBuildRing()
    {
        firstbutton.interactable = false;
        secondbutton.interactable = false;
        buildring.SetActive(true);
        buildring.transform.DOScale(transform.localScale * 1f, 0.3f);

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && abilityRing)
        {
            MouseLookNew.instance.look = false;
            MouseLookNew.instance.deger = false;
            mainrig.SetActive(true);
        }
        if (Input.GetKeyUp(KeyCode.Q) && abilityRing)
        {
            MouseLookNew.instance.look = true;
            MouseLookNew.instance.deger = true;
            firstbutton.interactable = true;
            secondbutton.interactable = true;
            mainrig.transform.DOScale(transform.localScale * 1f, 0.3f);
            petring.transform.DOScale(transform.localScale * 0.5f, 0.3f);
            buildring.transform.DOScale(transform.localScale * 0.5f, 0.3f);
            mainrig.SetActive(false);
            petring.SetActive(false);
            buildring.SetActive(false);
        }
    }
}
