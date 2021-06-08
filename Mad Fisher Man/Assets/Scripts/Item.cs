using System;
using UnityEngine;

[Serializable]
public class Item {
    public enum ItemType {
       Fish1,
       Fish2,
       Fish3,
       Fish4,
       Fish5,
       Fish6,
       Fish7,
       Fish8
    }
    public ItemType itemType;
    public int amount;
    public Sprite GetSprite() {
        switch (itemType) {
        default:
        case ItemType.Fish1:       return ItemAssets.Instance.fish1;
        case ItemType.Fish2:       return ItemAssets.Instance.fish2;
        case ItemType.Fish3:       return ItemAssets.Instance.fish3;
        case ItemType.Fish4:       return ItemAssets.Instance.fish4;
        case ItemType.Fish5:       return ItemAssets.Instance.fish5;
        case ItemType.Fish6:       return ItemAssets.Instance.fish6;
        case ItemType.Fish7:       return ItemAssets.Instance.fish7;
        case ItemType.Fish8:       return ItemAssets.Instance.fish8;
        }
    }
}
