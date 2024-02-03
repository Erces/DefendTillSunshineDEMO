using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Npc : MonoBehaviour
{
    public TextMeshProUGUI questText,questText2;
    public Color color;
    public Quest quest;
    public GameObject questBaloon,questPopUp,dialogue1,dialogue2;
    public int quest_mushroom, quest_fish;
    public int mushroom, fish;
    public List<Item> items;
    int countmushroom,countlog;
    void Start()
    {
        quest.isDone = false;
        
    }

    
    void Update()
    {
        
    }
    private void OnDisable()
    {
        Fishing.onCatchFish -= progressFish;
        PlayerMovement.onMushroomCollect -= progressMushroom;
    }
    public void startQuest()
    {
        Debug.Log("STARTING QUEST!");
        if (PlayerPrefs.GetInt("_language_index") == 1)
        {
            questText.text = quest.description_tr.ToString();
            questText2.text = quest.description_tr2.ToString();
        }
        if (PlayerPrefs.GetInt("_language_index") == 0)
        {
            questText.text = quest.description.ToString();
           questText2.text = quest.description2.ToString();
        }
        //First quest of the game 
        dialogue1.SetActive(false);
        questBaloon.SetActive(false);
        questPopUp.SetActive(true);
        Fishing.onCatchFish += progressFish;
       PlayerMovement.onMushroomCollect += progressMushroom;
    }
    public void checkDone(int _fish,int _mushroom)
    {
        if (_fish == quest_fish)
        {
            questText.color = Color.green;
        }
        if (_mushroom == quest_mushroom)
        {
            questText2.color = Color.green;
        }
        if (_fish >= quest_fish && _mushroom >= quest_mushroom)
        {
            GameObject.Find("!MAINCHARACTER").GetComponent<PlayerMovement>().abilityAxe = true;
            Debug.Log("Quest Bittican!");
            dialogue2.SetActive(true);
           questPopUp.SetActive(false);
            quest.isDone = true;
            Fishing.onCatchFish -= progressFish;
            PlayerMovement.onMushroomCollect -= progressMushroom;
            //   PlayerMovement.OnMushroom -= progressMushroom;
            countmushroom = 0;
            countlog = 0;
            foreach (var item in Inventory.instance.items)
            {
                
                Debug.Log(item.name);
                if (item.name == "Mushroom")
                {
                    
                    items.Add(item);
                    countmushroom++;
                    Debug.Log("Hazariyeee");
                }
                if(item.name == "Fish")
                {
                    
                    items.Add(item);
                    countlog++;
                    Debug.Log("Hazariyeee");
                }
                if (countmushroom == 3 && countlog == 1)
                {
                    Inventory.instance.items.Remove(items[0]);
                    Inventory.instance.items.Remove(items[0]);
                    Inventory.instance.items.Remove(items[0]);
                    Inventory.instance.items.Remove(items[0]);
                    Inventory.instance.items.Remove(items[0]);
                    Debug.Log("Ladder!");
                   
                   
                    
                    

                }

            }

        }
    }
    public void progressFish()
    {
        fish++;
        checkDone(fish, mushroom);
    }
    public void progressMushroom()
    {
        mushroom++;
        checkDone(fish, mushroom);
        
    }
}
