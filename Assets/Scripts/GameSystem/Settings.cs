using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Audio;
using Cinemachine;

public class Settings : MonoBehaviour
{
    public CinemachineFreeLook freelookcam;
    public AudioMixer audioMixer;
    public TMP_Dropdown resDropdown;
    public float _multiplier = 30f;
    //public Dropdown resDropdown;
    Resolution[] resolutions;
    void Start()
    {
        resolutions = Screen.resolutions;

        resDropdown.ClearOptions();

        List<string> options = new List<string>();
        int currentResIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if(resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResIndex = i;
            }
        }
        resDropdown.AddOptions(options);
        resDropdown.value = currentResIndex;
        resDropdown.RefreshShownValue();
    }

    public void SetSFXVolume (float volume)
    {
        Debug.Log(volume);
        audioMixer.SetFloat("SFXVolume", value: Mathf.Log10(volume) * _multiplier);
    }
    public void SetSoundtrackVolume(float volume)
    {
        Debug.Log(volume);
        audioMixer.SetFloat("SoundtrackVolume", value: Mathf.Log10(volume) * _multiplier);
        
    }
    public void SetFullscreen (bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
    public void SetResolution(int resIndex)
    {
        Resolution res = resolutions[resIndex];
        Screen.SetResolution(res.width, res.height, Screen.fullScreen);
    }
    public void Sensitivity (float volume)
    {
        freelookcam.m_XAxis.m_MaxSpeed = volume;
    }


}
