using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;
using Random = UnityEngine.Random;

public class Fisherman : MonoBehaviour
{
    public static Fisherman Instance {get; private set; }
    [SerializeField] private UI_Inventory uiInventory;
    private Inventory inventory;
    private int emptySlot = 8;

    private void Awake()
    {
        Instance = this;
        inventory = new Inventory();
        uiInventory.SetInventory(inventory);
        uiInventory.SetPlayer(this);
        
    }
    public Vector3 GetPosition() {
        return transform.position;
    }
    private int luckyNumber;
    
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
}
