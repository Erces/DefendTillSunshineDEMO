using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{
    [SerializeField] string _volumeParameter = "MasterVolume";
    [SerializeField] AudioMixer _mixer;
    [SerializeField] Slider _slider;
    [SerializeField] float _multiplier = 30f;

    private void Awake()
    {
        _slider.onValueChanged.AddListener(HandleSliderValueChanged);  
    }
    void Start()
    {
        _slider.value = PlayerPrefs.GetFloat(_volumeParameter, _slider.value);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnDisable()
    {
        PlayerPrefs.SetFloat(_volumeParameter, _slider.value);
    }
    public void HandleSliderValueChanged(float value)
    {
        _mixer.SetFloat(_volumeParameter, value:Mathf.Log10(value) * _multiplier);
    }
}
