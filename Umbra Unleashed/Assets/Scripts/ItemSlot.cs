using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IPointerClickHandler
{   //=============Item Data============//
    public string itemName;
    public int quantity;
    public Sprite itemSprite;
    public bool isFull;
    public string itemDescription;

    //=============Item Slot============//
    [SerializeField] private TMP_Text quantityText;
    [SerializeField] private GameObject quantityTextObject; // This is the object that holds the quantity text and is set to active when the item is added
    [SerializeField] private Image itemImage;
    
    //=============Item Description Slot============//
    public Image itemDescriptionImage;
    public TMP_Text itemNameText;
    public TMP_Text itemDescriptionText;

    public GameObject selectedShader;
    public bool isSelected;
    private InventoryManager inventoryManager;
    public Sprite emptySlotSprite;

    private void Start()
    {
        inventoryManager = GameObject.Find("InventoryManager").GetComponent<InventoryManager>();
    }
    public void AddItem(string itemName, int quantity, Sprite itemSprite , string itemDescription)
    {
        this.itemName = itemName;
        this.quantity = quantity;
        this.itemSprite = itemSprite;
        this.itemDescription = itemDescription;
        itemImage.sprite = itemSprite;
        quantityText.text = quantity.ToString();
        quantityTextObject.SetActive(true); // Set the quantity text object to active
        isFull = true;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            OnLeftClick();
        }
        else
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            OnRightClick();
        }
    }

    private void OnLeftClick()
    {
        inventoryManager.DeselectAll();
        Debug.Log("Left click on " + itemName);
        selectedShader.SetActive(true);
        isSelected = true;
        itemDescriptionImage.sprite = itemSprite;
        itemNameText.text = itemName;
        itemDescriptionText.text = itemDescription;
        if (itemDescriptionImage.sprite == null)
        {
            itemDescriptionImage.sprite = emptySlotSprite;
        }
        
    }

    private void OnRightClick()
    {
        Debug.Log("Right click on " + itemName);
    }

   
}
