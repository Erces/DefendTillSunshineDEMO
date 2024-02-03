using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.Animations.Rigging;
using DG.Tweening;
public class Gun : MonoBehaviour
{
    public Transform player;
    public bool abilityShoot;
    public LayerMask ignore;
    public TrailRenderer tracerEffect;
    public Rig aimLayer;
    public float aimDuration = 0.3f;
    public Animator shootanimator;
    public Animation shoot;
    
    [Header("GunSpecs")]
    public int ammoCount;
   public int damage = 10;
    public int range = 80;
    public float force = 50f;
    private float nextTimeToFire = 0f;
    public float fireRate = 15;
    [Header("Others")]
    public GameObject impactEffect,bottleEffect,smokeEffect,smokePosition;
    private float acceleration = 0.2f;

    CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin;
    public float duration,  strength, randomness;
    public int vibrato;


    public CinemachineVirtualCamera normalCam;
    public CinemachineVirtualCamera gunCam;
    public CinemachineBrain cine;
    void Start()
    {
        abilityShoot = true;
        DOTween.Init();
        cinemachineBasicMultiChannelPerlin = gunCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(1) && abilityShoot)
        {
            aimLayer.weight += 1;
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = Mathf.Clamp(cinemachineBasicMultiChannelPerlin.m_AmplitudeGain - acceleration * Time.deltaTime, 0, 1);
                
            }
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = 1;
            }
            if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire && ammoCount > 0 && abilityShoot)
            {
                nextTimeToFire = Time.time + 1f / fireRate;
                Shoot();
            }
        }
        else
        {
            aimLayer.weight = 0;
            //aimLayer.weight -= Time.deltaTime / aimDuration;
        }

    }
    void Shoot()
    {
       //// shootanimator.SetTrigger("Bow");
        var tracer = Instantiate(tracerEffect, smokePosition.transform.position, Quaternion.identity);
        tracer.AddPosition(smokePosition.transform.position);
        GameObject impactsmoke = Instantiate(smokeEffect,smokePosition.transform);
        Destroy(impactsmoke, 2);
        CameraShake.Instance.ShakeZoomCamera(duration, strength, vibrato, randomness);

        SoundEffects.instance.playGunSound();
        Debug.Log("shootign");
        normalCam = cine.ActiveVirtualCamera.VirtualCameraGameObject.GetComponent<CinemachineVirtualCamera>();
        RaycastHit hitanimal;

        
        ammoCount--;
        RaycastHit hit;
        if (Physics.Raycast(gunCam.transform.position, gunCam.transform.forward,out hit, range,-5, QueryTriggerInteraction.Ignore))
        {
            tracer.transform.position = hit.point;
            Debug.Log("Hit name" + hit.transform.name);
            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * force);
            }
            if (hit.transform.tag == "Enemy")
            {
                hit.transform.GetComponent<Enemy>().takeDamage(50);
            }
            if(hit.transform.tag == "Animal")
            {
                hit.transform.root.gameObject.GetComponent<Animal>().takeDamage(damage);
                hit.transform.root.gameObject.GetComponent<FoxYapayZeka>().enemy = this.transform.root.transform;
                GameObject impact = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(impact, 2);
            }
            if (hit.transform.tag == "R_Animal")
            {
                hit.transform.root.gameObject.GetComponent<Animal>().takeDamageRight(damage);
                hit.transform.root.gameObject.GetComponent<FoxYapayZeka>().enemy = this.transform.root.transform;
                GameObject impact = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(impact, 2);
            }
            if (hit.transform.tag == "L_Animal")
            {
                hit.transform.root.gameObject.GetComponent<Animal>().takeDamageLeft(damage);
                hit.transform.root.gameObject.GetComponent<FoxYapayZeka>().enemy = this.transform.root.transform;
                GameObject impact = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(impact, 2);
            }
            if (hit.transform.tag == "Bottle")
            {
                hit.transform.root.gameObject.GetComponent<Bottle>().Shatter();
                GameObject impact = Instantiate(bottleEffect, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(impact, 2);
            }
            if (hit.transform.tag == "AnimalHead")
            {
                hit.transform.root.gameObject.GetComponent<Animal>().takeDamage(damage * 2);
                hit.transform.root.gameObject.GetComponent<FoxYapayZeka>().enemy = this.transform.root.transform;
                GameObject impact = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impact, 2);
            }
            
            

        }
    }
    
}
