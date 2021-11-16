using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using ISlot = IInventory.ISlot;

public class IInventoryUI : MonoBehaviour
{
    [SerializeField] private GameObject slotPrefab;
    [SerializeField] private TextMeshProUGUI itemName, itemDescription;
    [SerializeField] private Button useButton, dropButton;
    [SerializeField] private TMP_InputField quantityToDrop;
    [SerializeField] private Image itemIcon;
    [SerializeField] private Transform slotList;

    private IInventory inventory;
    private void Start() => inventory = FindObjectOfType<IInventory>();

    public void Synchronize()
    {
        foreach (Transform child in slotList) if (child.gameObject != slotPrefab) Destroy(child.gameObject);
        foreach (ISlot slot in inventory.Get)
        {
            Transform newSlot = Instantiate(slotPrefab, slotList).transform;
            newSlot.GetComponentInChildren<TextMeshProUGUI>().text = (slot.quantity < 100 ? slot.quantity.ToString() : "99+");
            newSlot.Find("_").Find("Icon").GetComponent<Image>().sprite = slot.item.icon;
            newSlot.GetComponent<Button>().onClick.AddListener(() => Select(slot));
            newSlot.gameObject.SetActive(true);
        }
    }

    private void Select(ISlot slot)
    {

    }

    [System.Serializable]
    public class ISlotUI
    {
        public Image icon;
        public TextMeshProUGUI quantity;
    }
}