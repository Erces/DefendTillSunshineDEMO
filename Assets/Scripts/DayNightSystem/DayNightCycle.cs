using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DayNightCycle : MonoBehaviour
{
    public delegate void OnNextDay();
    public static event OnNextDay onDayPass;


    public Animator cycleanimator;
    [Range(0, 24)]
    public float timeOfDay;
    public int Day;
   // public Text txt;

    public float orbitSpeed = 1.0f;
    public Light sun;
    public Light moon;

    public float temperature;
    public bool isNight;

    public static DayNightCycle Instance;
    private void Awake()
    {
        if (Instance!= null)
        {
            Debug.Log("Already has instance daynightcycle");
            return;
        }
        Instance = this;

    }
    void Start()
    {
        Day = 1;
        
    }
    private void Update()
    {

        timeOfDay += Time.deltaTime * orbitSpeed;
        
        
        if (timeOfDay > 24)
        {
            timeOfDay = 0;
            NextDay();
           // txt.text = (Day).ToString();
            cycleanimator.SetTrigger("Cycle");
        }
        UpdateTime();
    }
    private void OnValidate()
    {
        UpdateTime();
    }
    public void NextDay()
    {
        Day++;
        Debug.Log("NextDayFunction");
        onDayPass?.Invoke();
        

    }
    // Update is called once per frame
    void UpdateTime()
    {
        float alpha = timeOfDay / 24f;
        float sunRotation = Mathf.Lerp(-90, 270, alpha);
        float moonRotation = sunRotation - 180;

        sun.transform.rotation = Quaternion.Euler(sunRotation, 0, 0);
        moon.transform.rotation = Quaternion.Euler(moonRotation, 0, 0);

        CheckNightDayTransition();
    }
    private void CheckNightDayTransition()
    {
        if (isNight)
        {
            if(moon.transform.rotation.eulerAngles.x > 180)
            {
                StartDay();
            }
        }
        else
        {
            if (sun.transform.rotation.eulerAngles.x > 180)
            {
                StartNight();
            }
        }
    }
    private void StartDay()
    {
        isNight = false;
        sun.shadows = LightShadows.Soft;
        moon.shadows = LightShadows.None;
    }
    private void StartNight()
    {
        isNight = true;
        sun.shadows = LightShadows.None;
        moon.shadows = LightShadows.Soft;
    }
}
