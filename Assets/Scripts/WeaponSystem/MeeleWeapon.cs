using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class MeeleWeapon : MonoBehaviour
{


    [SerializeField] private float damage, durability,rarity,range,attackrate;
    private float timer;
    
    public CinemachineFreeLook cam;
    public LayerMask animal;
    private bool ableToAttack;


    private AudioSource source;
    [SerializeField] private AudioClip swordclip;

    // Update is called once per frame
    private void Start()
    {
        source = GetComponent<AudioSource>();
        timer = attackrate;
        ableToAttack = false;
    }
    void Update()
    {
        timer -= Time.deltaTime;
        if (Input.GetMouseButton(0) && timer <= 0)
        {
            ableToAttack = true;
           attack();
        }
    }
    void attack()
    {
        Invoke("swordSound", 0.23f);
        PlayerMovement.instance.animator.SetTrigger("Sword1");
        
        Invoke("waitforcamerashake", 0.5f);
        Vector3 fwd = Camera.main.transform.TransformDirection(Vector3.forward);
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, fwd, out hit, 5, animal))
        {
            Debug.Log(hit.transform.root.name);
            if (hit.transform.tag == "Animal")
            {
                
                hit.transform.root.GetComponent<Animal>().takeDamage((int)damage);
            }
           if (hit.transform.tag == "L_Animal")
            {
               
                hit.transform.root.GetComponent<Animal>().takeDamageLeft((int)damage);
            }
            if (hit.transform.tag == "R_Animal")
            {
                hit.transform.root.GetComponent<Animal>().takeDamageRight((int)damage);
            }
        }
        timer = attackrate;
    }
    void swordSound()
    {
        source.PlayOneShot(swordclip);
    }
    private void OnTriggerEnter(Collider hit)
    {

        if (ableToAttack)
        {



            if (hit.tag == "Animal")
            {
                ableToAttack = false;
                Debug.Log("Animal hit");
                hit.transform.root.GetComponent<Animal>().takeDamage((int)damage);
            }
            if (hit.tag == "L_Animal")
            {
                ableToAttack = false;

                Debug.Log("Animal hit");

                hit.transform.root.GetComponent<Animal>().takeDamageLeft((int)damage);
            }
            if (hit.tag == "R_Animal")
            {
                ableToAttack = false;

                Debug.Log("Animal hit");
                hit.transform.root.GetComponent<Animal>().takeDamageRight((int)damage);
            }
        }
    }
    public void waitforcamerashake()
    {
        CameraShake.Instance.ShakeCamera(25, 0.25f);

    }
}
