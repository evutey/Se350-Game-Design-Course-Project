using System;
using System.Collections.Generic;
public class Inventory {
    private List<Item> itemList;
    private Action<Item> useItemAction;
    public Inventory() {
        itemList = new List<Item>();
    }
    public void AddItem(Item item) {
        itemList.Add(item);
    }
    public void RemoveItem(Item item) {
        itemList.Remove(item);
    }
    public List<Item> GetItemList() {
        return itemList;
    }
}
