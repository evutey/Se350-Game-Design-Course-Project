using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEditorInternal.Profiling.Memory.Experimental;
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

    private void Awake()
    {
        Instance = this;
        inventory = new Inventory();
        uiInventory.SetInventory(inventory);
        uiInventory.SetPlayer(this);
        purse = 0;

    }
    public Vector3 GetPosition() {
        return transform.position;
    }
    


   
    void Update()
    {
        if (emptySlot !=8 )
            if (Input.GetKeyDown(KeyCode.S))
            {
                inventory.GetItemList().RemoveAt(inventory.GetItemList().Count-1);
                emptySlot++;
            }

        if (emptySlot !=0)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                luckyNumber = Random.Range(0, 100);
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
}
