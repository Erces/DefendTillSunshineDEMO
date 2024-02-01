using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class Book : MonoBehaviour
{
    public GameObject book,ring;
    public Transform compass;
    public Transform north;
    public Text foxtoken;
    public Text deertoken;
    public Text day, temp;
    private int daycount;
    public AudioSource booksource;
    public AudioClip clip;
    private bool isOpen = false;
    private void OnEnable()
    {
        DayNightCycle.onDayPass += BookUpdateUI;
    }
    private void Start()
    {
        
        DOTween.Init();
        PlayerPrefs.SetInt("Fox", 50);
        PlayerPrefs.SetInt("Deer", 50);


        BookUpdateUI();
    }
    private void Update()
    {
        compass.LookAt(north);
        if (Input.GetKeyDown(KeyCode.B))
        {
            ring.SetActive(false);
            booksource.PlayOneShot(clip);
            isOpen = !isOpen;
            book.SetActive(isOpen);
            MouseLookNew.instance.deger = !isOpen;
            MouseLookNew.instance.look = !isOpen;
           
        }
    }
    void BookUpdateUI()
    {
        PlayerPrefs.SetInt("Fox", PlayerPrefs.GetInt("Fox") + 50);
        PlayerPrefs.SetInt("Deer", PlayerPrefs.GetInt("Deer") + 50);
        Debug.Log("Book event");
        daycount = DayNightCycle.Instance.Day;
        day.text = daycount.ToString();
        foxtoken.text = PlayerPrefs.GetInt("Fox").ToString();
        deertoken.text = PlayerPrefs.GetInt("Deer").ToString();
    }
    private void OnDisable()
    {
        DayNightCycle.onDayPass -= BookUpdateUI;
    }
}

