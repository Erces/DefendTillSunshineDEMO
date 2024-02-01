using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.Animations.Rigging;
using System;
using UnityEngine.Events;

public class PlayerMovement : MonoBehaviour
{
    public float rotationSpeed = 4;
    Vector3 StickDirection;
    public GameObject newCamera;
    public bool abilityFish,abilityPickUp,abilityAxe;
    public delegate void OnFishing();
    public static event OnFishing onFishingStart;
   
    
    public  delegate void OnMushroom();
   public static event OnMushroom onMushroomCollect;

    public GameObject gun,hatchet;
    public GameObject riggun,righatchet;


    public GameObject camholder;
    public Animator animator;
    [SerializeField]  private CharacterController controller;
    public float dodgetransformspeed;
    public float speed = 1f;
    public float speedmultiplayer = 1f;
    public float gravity = -10f;
    public float jumph = 5f;
    public float stealthlevel = 1f;
    public float stamina = 100f,staminalowerspeed,staminaraisespeed;

     public float timer = 3f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public LayerMask water,tree;
    public LayerMask door;
    Vector3 velocity;
    public bool isGrounded;
    private GameObject doorr;
    public float deger;
    public float x;
    public float z;

    public GameObject runprojectile;
    public Transform runeffect;
    public Transform cameraTransform;

    public static PlayerMovement instance;


    private void Awake()
    {
        if (instance!= null)
        {
            Debug.Log("playermovement instance error");
        }
        instance = this;

    }
    void Start()
    {
        abilityFish = false;
        abilityPickUp = true;
        abilityAxe = true;
        controller = this.GetComponent<CharacterController>();

        
    }
    void takeGunBack()
    {
        gun.SetActive(true);
        riggun.GetComponent<Rig>().weight = 1;
        hatchet.SetActive(false);
        righatchet.GetComponent<Rig>().weight = 0;

        
    }

    // Update is called once per frame
    void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        if (stamina < 100)
        {
            stamina += staminaraisespeed * Time.deltaTime;
        }
        
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 rotOfset2 = Camera.main.transform.TransformDirection(StickDirection);
            rotOfset2.y = 0;


            gameObject.transform.forward = Vector3.Slerp(this.transform.forward, rotOfset2, Time.deltaTime * rotationSpeed);
            Debug.Log("Raycast!");
            RaycastHit hit;
            Vector3 fwd = Camera.main.transform.TransformDirection(Vector3.forward);
            
            if (Physics.Raycast(camholder.transform.position, fwd, out hit, 5, door))
            {
                Debug.Log("Door hit!");
                Debug.Log(hit.collider.gameObject.name);
                hit.collider.gameObject.GetComponent<DoorOpen>().triggerDoor();
            }
            if (Physics.Raycast(Camera.main.transform.position, fwd, out hit, 8, water) && abilityFish)
            {
                Debug.Log("Water hit!");
                Debug.Log(hit.collider.gameObject.name);
                onFishingStart?.Invoke();
            }
            

        }
        if (Input.GetKeyDown(KeyCode.V) && abilityAxe)
        {

            gun.SetActive(false);
            riggun.GetComponent<Rig>().weight = 0;

            hatchet.SetActive(true);
            righatchet.GetComponent<Rig>().weight = 1;
            Debug.Log("Tree hit!");



            animator.SetTrigger("Hatchet");


        }


     //   velocity.y -= gravity * Time.deltaTime;
      //  controller.Move(velocity * Time.deltaTime);
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (Input.GetMouseButton(1))
        {
            animator.SetBool("isAiming", true);
        }
        if (Input.GetMouseButtonUp(1))
        {
            animator.SetBool("isAiming", false);
        }
        if (Input.GetMouseButtonDown(0))
        {
            animator.SetBool("isShooting", true);
        }
        if (Input.GetMouseButtonUp(0))
        {
            animator.SetBool("isShooting", false);
        }
       
      
     
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

         x = Input.GetAxis("Horizontal");
         z = Input.GetAxis("Vertical");
        deger = Mathf.Abs(x) + Mathf.Abs(z);
        StickDirection = new Vector3(x, 0, z);
        
        animator.SetFloat("degerx", x);
        animator.SetFloat("degerz", z);
        animator.SetFloat("deger", deger);
        Vector3 movementDirection = new Vector3(x, 0, z);
        float inputMagnitude = Mathf.Clamp01(movementDirection.magnitude);
        float mspeed = inputMagnitude * speed;
        movementDirection = Quaternion.AngleAxis(cameraTransform.rotation.eulerAngles.y, Vector3.up) * movementDirection;
      //  movementDirection.Normalize();

        Vector3 move =   transform.forward * (z) + transform.right * (x);
        Vector3 move2 = movementDirection * speed; ;
        Vector3  rotOfset = Camera.main.transform.TransformDirection(StickDirection);
        rotOfset.y = 0;
        
        
        gameObject.transform.forward = Vector3.Slerp(this.transform.forward, rotOfset, Time.deltaTime * rotationSpeed);

       
        

        Vector3 run = transform.forward * z * 5;
        if (Input.GetKey(KeyCode.LeftShift) && deger > 0.01 && stamina >= 30)
        {
            stamina -= Time.deltaTime * staminalowerspeed;
            animator.SetBool("isRunning", true);
           
            riggun.GetComponent<Rig>().weight = 0;
            speedmultiplayer = 1.6f;
            stealthlevel = 2f;
            if (runprojectile != null)
                Instantiate(runprojectile, runeffect.position, Quaternion.identity);
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            
            righatchet.GetComponent<Rig>().weight = 0;
            riggun.GetComponent<Rig>().weight = 0;
           
            animator.SetBool("isRunning", false);
            speedmultiplayer = 1f;
            stealthlevel = 1f;
        }
        
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            controller.Move(move2 * speedmultiplayer * 3* Time.deltaTime);

            animator.SetTrigger("Dodge");
        }


       controller.Move(move2 * speedmultiplayer* Time.deltaTime);

        velocity.y -= gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);


    }
    private void OnTriggerStay(Collider col)
    {
        if (col.tag == "Item" && Input.GetKey(KeyCode.E) && abilityPickUp)
        {
            col.transform.GetComponent<ItemPickup>().PickUp();
            if(col.name == "mushroom")
            {
                onMushroomCollect?.Invoke();
            }
        }
        if (col.tag == "Workbench" && Input.GetKeyDown(KeyCode.C))
        {
            col.gameObject.GetComponent<Workbench>().Work();
        }
    }
   
    
}
