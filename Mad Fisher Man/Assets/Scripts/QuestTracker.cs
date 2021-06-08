using UnityEngine;
using UnityEngine.UI;

public class QuestTracker : MonoBehaviour
{
    public int quest_Counter;

    public int activeQuest;

    public bool isQuestActive;

    private string currentAvaibleQuestt;

    public GameObject currentQuestName, currentAvaibleQuest, questCounter, questNpcUI;

    public GameObject questAcceptButton, questNotAVaibleButton, fisherman;
    
    private Fisherman fm;
    
    public string GetQuest(int x)
    {
        switch (x) {
            case 1: return "Catch 8 times Fish1"; 
            case 2: return "Catch 8 times Fish2"; 
            case 3: return "Catch 8 times Fish3"; 
            case 4: return "Catch 8 times Fish4"; 
            case 5: return "Catch 8 times Fish5"; 
            case 6: return "Catch 8 times Fish6"; 
            case 7: return "Catch 8 times Fish7"; 
            case 8: return "Catch 8 times Fish8";
        }
        return null;
    }
    public int GetQuestReward(int x)
    {
        switch (x) {
            case 1: return 150; 
            case 2: return 250; 
            case 3: return 300; 
            case 4: return 400; 
            case 5: return 450; 
            case 6: return 500; 
            case 7: return 600; 
            case 8: return 1000;
        }
        return 0;
    }
    private void Awake()
    {
        fisherman = GameObject.Find("Fisherman");
        fm = fisherman.GetComponent<Fisherman>();
        currentAvaibleQuestt = GetQuest(1);
        activeQuest = 0;
        isQuestActive = false;

    }
    void Update()
    {
        if (isQuestActive)
        {
            if (quest_Counter >= 8) 
            {
                questCounter.GetComponent<Text>().text = "OK";
                quest_Counter = 0;
                fisherman.GetComponent<Fisherman>().purse += GetQuestReward(activeQuest);
                fisherman.GetComponent<Fisherman>().coin.text = fisherman.GetComponent<Fisherman>().purse.ToString();
                questAcceptButton.SetActive(true);
                questNotAVaibleButton.SetActive(false);
                isQuestActive = false;
            }
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Asker Detected.");
            if (Input.GetKey(KeyCode.T))
            {
                Debug.Log("T is pressed!");
                Debug.Log("Quest Screen is opened!");
                questNpcUI.SetActive(true);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            questNpcUI.SetActive(false);
        }
    }
    public void acceptQuest()
    {
        currentQuestName.GetComponent<Text>().text = currentAvaibleQuest.GetComponent<Text>().text;
        questCounter.GetComponent<Text>().text = "0/8";
        activeQuest++;
        isQuestActive = true;
        questAcceptButton.SetActive(false);
        questNotAVaibleButton.SetActive(true);
        currentAvaibleQuest.GetComponent<Text>().text = GetQuest((activeQuest+1));
    }
}
