using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;


public class DayManager : MonoBehaviour
{
    public AudioSource source;
    public AudioClip rainclip,normalclip;
    public Volume volume;
    public VolumeProfile rainy, snowy, suny;
    public GameObject SkyAndFog,RainEffect,SnowEffect;
    private int randomizer;
    Fog fog;
    [Header("Bools")]
    [SerializeField] private bool rain, snow, sun;
    

    [Header("Speeds")]
    [SerializeField] private float Temperature;
    [SerializeField] private float freezespeed;
    [SerializeField] private float warmspeed;
    [SerializeField] private float freezedamage;
    


    private PlayerSituation situation;
    private void OnEnable()
    {
        Debug.Log("Enabling event");
        DayNightCycle.onDayPass += RandomDaySituation;
    }
    void Start()
    {
        
        situation = PlayerSituation.instance;
        
    }


    // Update is called once per frame
    void Update()
    {
        Temperature -= freezespeed * Time.deltaTime;

        if (Temperature < 30)
        {
            situation.takeFreezeDamage(freezedamage);
        }
        if (Temperature <= 0)
        {
            Temperature = 0;
        }
        if (Temperature > 100)
        {
            Temperature = 100;
        }
    }

    void RandomDaySituation()
    {
        Debug.Log("RandomDaySituationWorking!");
        //volume.profile = snowy;
        rain = false;
        snow = false;
        sun = false;
        randomizer = Random.Range(1,3);
        Debug.Log(randomizer + "Randomizer");
        if (randomizer == 1)
        {
            //Day is rainy!
            source.clip = rainclip;
            source.Play();
            RainEffect.SetActive(true);
            SnowEffect.SetActive(false);
            rain = true;
            freezespeed = 1;
           // volume.profile = rainy;


        }
        else if (randomizer == 2)
        {
            Debug.Log("Randomizer is 2");
            //Day is snowy!
            source.clip = normalclip;
            source.Play();
            RainEffect.SetActive(false);
            SnowEffect.SetActive(true);
            snow = true;
            freezespeed = 3;
          //  volume.profile = snowy;


        }
        else
        {
            //Day is sunny!
            source.clip = normalclip;
            source.Play();
            RainEffect.SetActive(false);
            SnowEffect.SetActive(false);
            sun = true;
            freezespeed = 0;
           // volume.profile = suny;

        }

    }
    private void OnTriggerStay(Collider col)
    {
        if (col.tag == "Home" || col.tag == "Fireplace")
        {
            Temperature += warmspeed * Time.deltaTime;
        }


    }

    private void OnDisable()
    {
        Debug.Log("Disabling event");
        DayNightCycle.onDayPass -= RandomDaySituation;
    }
}
