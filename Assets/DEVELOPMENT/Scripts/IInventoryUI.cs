using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class IInventoryUI : MonoBehaviour
{
    [SerializeField] private ISlotUI slotPrefab;
    [SerializeField] private TextMeshProUGUI itemName, itemDescription;
    [SerializeField] private Button useButton, dropButton;
    [SerializeField] private TMP_InputField quantityToDrop;
    [SerializeField] private Image itemIcon;

    private IInventory inventory;
    private void Start() => inventory = FindObjectOfType<IInventory>();

    public void Synchronize()
    {
        
    }

    private void Select()
    {

    }

    [System.Serializable]
    public class ISlotUI
    {
        public Image icon;
        public TextMeshProUGUI quantity;
        public GameObject root;
    }
}