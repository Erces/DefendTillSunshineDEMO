using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DialogueManager : MonoBehaviour
{
    public Text npcname;
    public Text dialoguetext;
    public Text continuealert;
    public Queue<string> sentences;
    public static DialogueManager instance;
    public bool onDialogue = false;
    public bool questActive = false;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of inventory found!");
            return;
        }
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
        

    }
    private void Update()
    {
        if (onDialogue && Input.GetKeyDown(KeyCode.E) && !questActive)
        {
            DisplayNextSentence();
        }
    }
    public void StartDialogue(Dialogue dialogue)
    {
        Debug.Log("Starting Dialogue");
        npcname.text = dialogue.name;
        continuealert.text = " ";
        
        onDialogue = true;
        Debug.Log("Starting conversation with " + dialogue.name);

        sentences.Clear();

        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
         
        DisplayNextSentence();
    }
    public void DisplayNextSentence()
    {
        Debug.Log(sentences.Count);
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));

    }

    IEnumerator TypeSentence(string sentence)
    {
        int sayac = 0;
        dialoguetext.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            sayac++;
           
           
            dialoguetext.text += letter;
            if (sayac - 1 == sentence.ToCharArray().GetUpperBound(0))
            {
                yield return new WaitForSeconds(25);
                dialoguetext.text = null;
                continuealert.text = null;
                npcname.text = null;
                break;
            }
            yield return null;
        }
    }
    public void EndDialogue()
    {
        onDialogue = false;
        continuealert.text = null;
        dialoguetext.text = null;
        Debug.Log("conversation end");
    }


    // Update is called once per frame
   
}
