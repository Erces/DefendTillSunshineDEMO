using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscPanelToggle : MonoBehaviour
{
    public bool GameIsPaused = false;
    public GameObject options;
    public GameObject escmenu,book,ring,cooking,inv;
    public GameObject[] slots;
    public AudioSource[] source;
    void Start()
    {
        Resume();
        var temp = GameObject.FindGameObjectsWithTag("SoundSpots");
        source = new AudioSource[temp.Length];

        for (int i = 0; i < source.Length; i++)
        {
            source[i] = temp[i].GetComponent<AudioSource>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                
                Resume();
                
            }
            else
            {
                Pause();
            }
        }
    }
    void Pause()
    {
        for (int i = 0; i < source.Length; i++)
        {
            source[i].Pause();
        }
        MouseLookNew.instance.look = false;
        MouseLookNew.instance.deger = false;
        foreach (var item in slots)
        {
            item.SetActive(false);
        }
        book.SetActive(false);
        ring.SetActive(false);
        cooking.SetActive(false);
        escmenu.SetActive(true);
        inv.SetActive(false) ;
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
    public void Resume()
    {
        for (int i = 0; i < source.Length; i++)
        {
            source[i].UnPause();
        }
        MouseLookNew.instance.look = true;
        MouseLookNew.instance.deger = true;
        Screen.lockCursor = true;
        escmenu.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    public void OptionsToggle()
    {
        options.SetActive(!options.activeSelf);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
