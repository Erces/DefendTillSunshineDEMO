using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueTrigger : MonoBehaviour
{
    public Npc npc;
    public GameObject canvas,questPopUp;
    public NPCAudio npcaudio;
    public LayerMask player;
    public Dialogue dialogue,dialogue_tr;
    public DialogueManager manager;
    private bool dialoguestart = false;
    public bool hasQuest = false;
    public bool questTalk = true;
    public GameObject prize;
    public GameObject notifications;

    public void Start()
    {
        manager = DialogueManager.instance;
        if (npc != null)
        {
            hasQuest = true;
        }
    }
    public void Update()
    {
        if (hasQuest)
        {
            if (npc.quest.isDone)
            {
                questPopUp.SetActive(false);
                manager.questActive = false;
                questTalk = true;
            }
            if (Input.GetKeyDown(KeyCode.E) && Physics.CheckSphere(transform.position, 5, player) && PlayerPrefs.GetInt("_language_index") == 0 && questTalk)
            {
                Debug.Log("DenemeYapiyorum");
                if (npc.quest.isDone)
                {
                    notifications.GetComponent<Animator>().SetTrigger("Not");
                    NotificationHandlerMusic.instance.playNotSound();
                    Debug.Log("questdoneif");
                    questPopUp.SetActive(false);
                }
                else
                {

                    npc.startQuest();
                }
                manager.questActive = true;
                questTalk = false;
                Debug.Log("DenemeYapiyorum2");
                TriggerDialogue();
                dialoguestart = true;
                npcaudio.npcTalk();
                
                Debug.Log("DenemeYapiyorum3");
              
            }
            if (Input.GetKeyDown(KeyCode.E) && Physics.CheckSphere(transform.position, 5, player) && PlayerPrefs.GetInt("_language_index") == 1 && questTalk)
            {
                Debug.Log("DenemeYapiyorum");
                if (npc.quest.isDone)
                {
                    notifications.GetComponent<Animator>().SetTrigger("Not");
                    NotificationHandlerMusic.instance.playNotSound();
                    Debug.Log("questdoneif");
                    questPopUp.SetActive(false);
                }
                else
                {

                    npc.startQuest();
                }
                manager.questActive = true;
                questTalk = false;
                TriggerDialogueTr();
                dialoguestart = true;
                npcaudio.npcTalk();
               
                
            }
        }
        else
        {



            if (Input.GetKeyDown(KeyCode.E) && Physics.CheckSphere(transform.position, 5, player) && PlayerPrefs.GetInt("_language_index") == 0)
            {
                TriggerDialogue();
                npcaudio.npcTalk();
                Debug.Log("Kutok1");
                dialoguestart = true;
                
                
            }
            if (Input.GetKeyDown(KeyCode.E) && Physics.CheckSphere(transform.position, 5, player) && PlayerPrefs.GetInt("_language_index") == 1)
            {
                Debug.Log("Kutok2");
                dialoguestart = true;
                npcaudio.npcTalk();
                TriggerDialogueTr();
            }
         //   if (manager.onDialogue == false && dialoguestart == true)
          //  {
           //     Debug.Log("Kutok3");
            //    dialoguestart = false;
             //   canvas.SetActive(false);
           // }
        }
    }
   
    public void TriggerDialogue()
    {
        manager.StartDialogue(dialogue);
    }
    public void TriggerDialogueTr()
    {
        manager.StartDialogue(dialogue_tr);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            canvas.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            canvas.SetActive(false);
        }
    }
}
