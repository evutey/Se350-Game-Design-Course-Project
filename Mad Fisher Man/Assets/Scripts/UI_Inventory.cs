using UnityEngine;
using UnityEngine.UI;

public class UI_Inventory : MonoBehaviour {

    private Inventory inventory;
    private Transform itemSlotContainer;
    private Transform itemSlotTemplate;
    private Fisherman fisherman;

    private void Awake() {
        itemSlotContainer = transform.Find("itemSlotContainer");
        itemSlotTemplate = itemSlotContainer.Find("itemSlotTemplate");
    }
    public void SetPlayer(Fisherman fisherman) {
        this.fisherman = fisherman;
    }
    public void SetInventory(Inventory inventory) {
        this.inventory = inventory;
        
        RefreshInventoryItems();
    }
    private void Update()
    {
        RefreshInventoryItems();
    }
    private void RefreshInventoryItems() {
        foreach (Transform child in itemSlotContainer) {
            if (child == itemSlotTemplate) continue;
            Destroy(child.gameObject);
        }
        int x = 0;
        float y = 0;
        float itemSlotCellSize = 42;
        foreach (Item item in inventory.GetItemList()) {
            RectTransform itemSlotRectTransform = Instantiate(itemSlotTemplate, itemSlotContainer).GetComponent<RectTransform>();
            itemSlotRectTransform.gameObject.SetActive(true);
            
            itemSlotRectTransform.anchoredPosition = new Vector2(x * itemSlotCellSize, -y * itemSlotCellSize);
            Image image = itemSlotRectTransform.Find("Fish").GetComponent<Image>();
            image.sprite = item.GetSprite();
            
            x++;
            if (x >= 2 ) {
                x = 0;
                y = y + 0.35f;
            }
        }
    }
}
