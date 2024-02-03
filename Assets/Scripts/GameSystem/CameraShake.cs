using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using DG.Tweening;
public class CameraShake : MonoBehaviour
{
    public GameObject zoomCam;
    public static CameraShake Instance

    {
        get;
        private set;
    }
    public CinemachineFreeLook cinemachineVirtualCamera;
    public CinemachineVirtualCamera cam;

    public float shakeTimer;

    private void Awake()
    {
        
        Instance = this;
        cinemachineVirtualCamera = GetComponent<CinemachineFreeLook>();
    }

    public void ShakeCamera(float intensity,float time)
    {
        transform.DOShakePosition(0.3f, 0.2f, 15, 0.2f,false,true);
        CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin = cinemachineVirtualCamera.GetRig(0).GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        cinemachineBasicMultiChannelPerlin.m_FrequencyGain = intensity;
        CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin2 = cinemachineVirtualCamera.GetRig(1).GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        cinemachineBasicMultiChannelPerlin2.m_FrequencyGain = intensity;

        CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin3 = cinemachineVirtualCamera.GetRig(2).GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        cinemachineBasicMultiChannelPerlin3.m_FrequencyGain = intensity;



        shakeTimer = time; 
    }
    public void ShakeZoomCamera(float duration, float strength,int vibrato,float randomness)
    {
        zoomCam.transform.DOShakePosition(duration, strength, vibrato, randomness, false, true);
        // CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin = cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

        // cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = intensity;
        // shakeTimer = time; 
    }

    private void Update()
    {
        //transform.DOShakePosition(0.3f, 0.2f, 15, 0.2f, false, true);
        if (shakeTimer > 0)
        {
            shakeTimer -= Time.deltaTime;
            if (shakeTimer <= 0f)
            {

                  CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin = cinemachineVirtualCamera.GetRig(0).GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

                  cinemachineBasicMultiChannelPerlin.m_FrequencyGain = 0f;
                  CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin2 = cinemachineVirtualCamera.GetRig(1).GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

                cinemachineBasicMultiChannelPerlin2.m_FrequencyGain = 0f;
                CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin3 = cinemachineVirtualCamera.GetRig(2).GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

                cinemachineBasicMultiChannelPerlin3.m_FrequencyGain = 0f;

            }
        }
    }
}
