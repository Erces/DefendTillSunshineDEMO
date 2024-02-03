using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Windows.Speech;

public class Pet : MonoBehaviour
{


    private Dictionary<string, Action> keywordActions = new Dictionary<string, Action>();
    private KeywordRecognizer keywordRecognizer;
    public enum AIState { Idle, Walking, Chasing,Sit,Attack,Sleep,Explore }
    public AIState currentState = AIState.Idle;

   

    [Header("Animator")]
    [SerializeField] private Animator animator;

    [Header("PlayerAndDog")]
    public NavMeshAgent dog;
    public Transform player;

    [Header("LayerMasks")]
    
    public LayerMask whatIsPlayer;
    public LayerMask whatIsBear;
    public LayerMask whatIsGround;
    [Header("Bools")]
    private bool animationReady = false;
    

    [Header("Range")]
    public float chillrange;
    public float bearrange;
    public float remaining;
    public float playerFollowDistance;
   

    [Header("Times")]
   [SerializeField] private float timer,sleepTimer;


    [Header("Notification Texts")]
    public GameObject sleepingText;
   

    private Vector3[] points = new Vector3[4];
    private Vector3 sky;
    private bool isExploring;
    public int count;



    public static Pet instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("Error pet instance");
            return;
        }
        instance = this;
    }
    private void Start()
    {
        keywordActions.Add("sit", sitCommand);
        keywordActions.Add("follow", followCommand);
        //keywordActions.Add("otur", sitCommand);
        keywordRecognizer = new KeywordRecognizer(keywordActions.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += OnKeywordsRecognized;
        keywordRecognizer.Start();

        remaining = 15;
        animator = gameObject.GetComponent<Animator>();   
    }

    private void OnKeywordsRecognized(PhraseRecognizedEventArgs speech)
    {
        Debug.Log(speech.text);
        keywordActions[speech.text].Invoke();

    }

    private void Update()
    {
        sleepTimer -= Time.deltaTime * 1 / 3f;
        float distance =  Mathf.Abs(Vector3.Distance(dog.transform.position, player.transform.position));

        #region Sleep
        if (sleepTimer < 10)
        {
            currentState = AIState.Sleep;
            switchAnimations(currentState);
        }

        if (currentState == AIState.Sleep)
        {
            sleepTimer += Time.deltaTime;
            if (sleepTimer > 70)
            {
                //wake up!
                switchAnimations(AIState.Idle);
                Invoke("waitforAwakeAnim", 5.4f);
                
            }

        }
        #endregion

        if (distance > playerFollowDistance && currentState == AIState.Idle && currentState != AIState.Explore)
        {
            dog.SetDestination(player.transform.position);
            currentState = AIState.Chasing;
            switchAnimations(currentState);
        }
        if(currentState == AIState.Sit)
        {
            dog.ResetPath();

        }
        if (currentState == AIState.Chasing)
        {
            
            if (distance < playerFollowDistance && DoneReachingDestination())
            {
                currentState = AIState.Idle;
                switchAnimations(currentState);

            }
            else
            {
                dog.SetDestination(player.transform.position);
            }
        }
        if (currentState == AIState.Explore)
        {
            if (DoneReachingDestination())
            {
                Explore();
            }
        }
       
       
       
        
       
        
     

    }
    void switchAnimations(AIState state)
    {
        animator.SetBool("Chasing", state == AIState.Chasing);
        animator.SetBool("Sit", state == AIState.Sit);
        animator.SetBool("Idle", state == AIState.Idle);
        animator.SetBool("Sleep", state == AIState.Sleep);
        animator.SetBool("Chasing", state == AIState.Explore);

        sleepingText.SetActive(state == AIState.Sleep);

        if (state == AIState.Attack)
        {
            Debug.Log("Triggering attack anim");
            animator.SetTrigger("Attack");
        }
    }

    public GameObject FindBear()
    {
        GameObject[] closestBear = GameObject.FindGameObjectsWithTag("Bear");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach(GameObject go in closestBear)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;

            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }
        return closest;
    }
    public void sitCommand()
    {
       
        currentState = AIState.Sit;
        switchAnimations(currentState);
        
    }
    public void followCommand()
    {
      //  followingplayer = true;
        switchAnimations(AIState.Chasing);
        Invoke("waitforAnim", 1.9f);
      
        
    }
    public void sitAnimation()
    {
        animationReady = true;
    }
    public void sitAnimationLock()
    {
        animationReady = false;
    }

    public void waitforAnim()
    {
        currentState = AIState.Idle;
        switchAnimations(currentState);
        //followingplayer = true;
    }
    private void waitforAwakeAnim()
    {
        currentState = AIState.Idle;
;        
    }


    public void Explore()
    {
        if (count == 4)
        {
            isExploring = false;
            dog.SetDestination(player.transform.position);
            currentState = AIState.Chasing;
            count = 0;
            return;
            
        }
        isExploring = true;
        currentState = AIState.Explore;
        points[0] = new Vector3(transform.position.x + UnityEngine.Random.Range(0, 10), transform.position.y, transform.position.z + UnityEngine.Random.Range(0, 10));
        points[1] = new Vector3(transform.position.x + UnityEngine.Random.Range(0, 10), transform.position.y, transform.position.z + UnityEngine.Random.Range(0, 10));
        points[2] = new Vector3(transform.position.x + UnityEngine.Random.Range(0, 10), transform.position.y, transform.position.z + UnityEngine.Random.Range(0, 10));
        points[3] = new Vector3(transform.position.x + UnityEngine.Random.Range(0, 10), transform.position.y, transform.position.z + UnityEngine.Random.Range(0, 10));

        Vector3 sky2 = (Vector3.up * 100) + points[count];

        RaycastHit hit;







        checkExploreLocation(sky2, count);
        count++;


    }
    public bool checkExploreLocation(Vector3 sky, int count)
    {
        RaycastHit hit;
        if (Physics.Raycast(sky, Vector3.down, out hit, 400))
        {
            if (hit.transform != null)
            {
                Pet.instance.chillrange = 500;
                dog.SetDestination(points[count]);
                currentState = AIState.Explore;
                switchAnimations(currentState);
                return true;
            }
            else
            {
                count--;
                return false;
            }
        }
        return false;
    }
    bool DoneReachingDestination()
    {
        if (!dog.pathPending)
        {
            if (dog.remainingDistance <= dog.stoppingDistance)
            {
                if (!dog.hasPath || dog.velocity.sqrMagnitude == 0f)
                {
                    //Done reaching the Destination
                    Debug.Log("TrueReaching");
                    return true;
                }
            }
        }
        Debug.Log("FalseReaching");

        return false;
    }

 /*   private void MoveObject()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo, 15, whatIsGround))
        {
            cursor.transform.position = hitInfo.point;
            cursor.transform.rotation = Quaternion.FromToRotation(Vector3.up, hitInfo.normal);
        }


    }*/

   /* void moveCursor()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (cursor == null)
            {
                cursor = Instantiate(placeObject);
            }

        }
        if (Input.GetKeyUp(KeyCode.F))
        {
            if (cursor != null)
            {
                Destroy(cursor);
            }
        }
    }
   */
}
