using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;
using Random = UnityEngine.Random;

public class Fisherman : MonoBehaviour
{
    public static Fisherman Instance {get; private set; }
    [SerializeField] private UI_Inventory uiInventory;
    private Inventory inventory;
    private int emptySlot = 8;
    private int luckyNumber;
    private int purse;
    public Text coin;
    private bool fishNow;
    private bool isFishing;
    private bool isThrow;
    
    private float fishTimer;
    private float fishAbleTime;
    private bool isFishingArea;
    public Animator _animator;
    private bool isMissed;
    private bool isCatched;
    public GameObject fish_icon;
    private int minTime;
    private int maxTime;
    private int currentUpgradeLevel;
    private int extraLuck;

    private Image olta_image;
    public Sprite olta1;
    public Sprite olta2;
    public Sprite olta3;
    public Sprite olta4;
    public Text minText;
    public Text maxText;
    public Text extraLuckText;
    

    private void Awake()
    {
        Instance = this;
        inventory = new Inventory();
        uiInventory.SetInventory(inventory);
        uiInventory.SetPlayer(this);
        fishNow = false;
        fishTimer = Random.Range(minTime, maxTime);
        fishAbleTime = 1f;
        isFishing = false;
        isFishingArea = false;
        isThrow = false;
        isMissed = false;
        isCatched = false;
        currentUpgradeLevel = 0;
        purse = 5000;
        coin.text = purse.ToString();
        minTime = 12;
        maxTime = 16;
        extraLuck = 0;
        olta_image = GameObject.Find("Olta_icon").GetComponent<Image>();
        olta_image.sprite = olta1;
    }
    public Vector3 GetPosition() {
        return transform.position;
    }
    
    void Update()
    {
        if (isFishingArea && Input.GetKeyDown(KeyCode.K))
        {
            Debug.Log("k PRESSESD!");
            _animator.SetBool("Catch", false);
            _animator.SetBool("Throw", true);
            isFishing = true;
            isMissed = false;
            isCatched = false;
        }
        if (isFishing)
        {
            _animator.SetBool("Fish", true);
           
            fishTimer -= Time.deltaTime;
            if (fishTimer <= 0)
            {
                fishNow = true;
                fish_icon.SetActive(true);
                
                Debug.Log("Press Space Now");
                
            }
            if (fishNow)
            {
                fishAbleTime -= Time.deltaTime;
            }
            if (fishAbleTime <=0)
            {
                fishNow = false;
                isFishing = false;
                fishTimer = Random.Range(minTime, maxTime);
                fishAbleTime = 1f;
                _animator.SetBool("Throw", false);
                _animator.SetBool("Fish", false);
                _animator.SetBool("Catch", true);
                fish_icon.SetActive(false);
                if (isMissed)
                {
                    _animator.SetBool("Missed", true);
                }
            }
        }
        /*if (emptySlot !=8 )
            if (Input.GetKeyDown(KeyCode.S))
            {
                inventory.GetItemList().RemoveAt(inventory.GetItemList().Count-1);
                emptySlot++;
            }*/
        if (emptySlot !=0 && fishNow)
        {
            isMissed = true;
            _animator.SetBool("Throw", false);
            _animator.SetBool("Fish", false);
            if (Input.GetKeyDown(KeyCode.Space) && !isCatched)
            {
                _animator.SetBool("Catch", true);
                isMissed = false;
                fishNow = false;
                isCatched = true;
                luckyNumber = Random.Range(0, 100);
                luckyNumber += extraLuck;
                if (luckyNumber > 100)
                {
                    luckyNumber = 100;
                }
                Debug.Log("You catch a fish!");
                if (luckyNumber <= 25)
                {
                    inventory.AddItem(new Item { itemType = Item.ItemType.Fish1, amount = 1 });
                }
                if (luckyNumber <= 45 && luckyNumber > 25)
                {
                    inventory.AddItem(new Item { itemType = Item.ItemType.Fish2, amount = 1 });
                }
                if (luckyNumber <= 60 && luckyNumber > 45)
                {
                    inventory.AddItem(new Item { itemType = Item.ItemType.Fish3, amount = 1 });
                }
                if (luckyNumber <= 70 && luckyNumber > 60)
                {
                    inventory.AddItem(new Item { itemType = Item.ItemType.Fish4, amount = 1 });
                }
                if (luckyNumber <= 79 && luckyNumber > 70)
                {
                    inventory.AddItem(new Item { itemType = Item.ItemType.Fish5, amount = 1 });
                }
                if (luckyNumber <= 87 && luckyNumber > 79)
                {
                    inventory.AddItem(new Item { itemType = Item.ItemType.Fish6, amount = 1 });
                }
                if (luckyNumber <= 94 && luckyNumber > 87)
                {
                    inventory.AddItem(new Item { itemType = Item.ItemType.Fish7, amount = 1 });
                }
                if (luckyNumber <= 100 && luckyNumber > 94)
                {
                    inventory.AddItem(new Item { itemType = Item.ItemType.Fish8, amount = 1 });
                }
                emptySlot--;
                Debug.Log(inventory.GetItemList().Count);
            }
        }
    }

    public void upgradeButton(int x)
    {
        switch (x)
        {
            case 1:
                if (purse >=300 && currentUpgradeLevel == 0)
                {
                    purse -=300;
                    coin.text = purse.ToString();
                    minTime = 10;
                    maxTime = 14;
                    extraLuck = 5;
                    minText.text = minTime.ToString();
                    maxText.text = maxTime.ToString();
                    extraLuckText.text = extraLuck.ToString();
                    olta_image.sprite = olta2;
                    currentUpgradeLevel++;
                }
                break;
            case 2:
                if (purse >=500 && currentUpgradeLevel == 1)
                {
                    purse -=500;
                    coin.text = purse.ToString();
                    minTime = 8;
                    maxTime = 12;
                    extraLuck = 10;
                    minText.text = minTime.ToString();
                    maxText.text = maxTime.ToString();
                    extraLuckText.text = extraLuck.ToString();
                    olta_image.sprite = olta3;
                    currentUpgradeLevel++;
                }
                break;
            case 3:
                if (purse >=1000 && currentUpgradeLevel == 2)
                {
                    purse -=1000;
                    coin.text = purse.ToString();
                    minTime = 6;
                    maxTime = 10;
                    extraLuck = 15;
                    minText.text = minTime.ToString();
                    maxText.text = maxTime.ToString();
                    extraLuckText.text = extraLuck.ToString();
                    olta_image.sprite = olta4;
                    currentUpgradeLevel++;
                }
                break;
        }
    }
    public void sellButton(int price)
    {
        Item fish1 = new Item { itemType = Item.ItemType.Fish1};
        Item fish2 = new Item { itemType = Item.ItemType.Fish2};
        Item fish3 = new Item { itemType = Item.ItemType.Fish3};
        Item fish4 = new Item { itemType = Item.ItemType.Fish4};
        Item fish5 = new Item { itemType = Item.ItemType.Fish5};
        Item fish6 = new Item { itemType = Item.ItemType.Fish6};
        Item fish7 = new Item { itemType = Item.ItemType.Fish7};
        Item fish8 = new Item { itemType = Item.ItemType.Fish8};
        switch (price)
        {
            case 10:
                removeItem(fish1, 10);
                break;
            case 15:
                removeItem(fish2, 15);
                break;
            case 25:
                removeItem(fish3, 25);
                break;
            case 35:
                removeItem(fish4, 35);
                break;
            case 45:
                removeItem(fish5, 45);
                break;
            case 60:
                removeItem(fish6, 60);
                break;
            case 75:
                removeItem(fish7, 75);
                break;
            case 100:
                removeItem(fish8, 100);
                break;
        }
    }
    public void removeItem(Item x, int price)
    {
        foreach (var item in inventory.GetItemList())
        {
            if (item.itemType == x.itemType)
            {
                inventory.GetItemList().Remove(item);
                emptySlot++;
                purse += price;
                coin.text = purse.ToString();
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("fishArea"))
        {
            Debug.Log("Fishing area is OK!");
            isFishingArea = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("fishArea"))
        {
            isFishingArea = false;
            Debug.Log("Fishing area is not avaible");
        }
    }
}
