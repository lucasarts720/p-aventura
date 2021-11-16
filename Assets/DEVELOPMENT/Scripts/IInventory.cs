using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IInventory : MonoBehaviour
{
    public List<ISlot> Get => slots;
    private List<ISlot> slots;
    private IInventoryUI ui;

    private void Start()
    {
        slots = new List<ISlot>();
        ui = FindObjectOfType<IInventoryUI>();
    }

    public void Add(IItem item, int quantity)
    {
        if (Find(item.name, out ISlot slot) != null && slot.item.stackable) slot.quantity += quantity;
        else slots.Add(new ISlot(item, quantity));
        ui.Synchronize();
    }

    public void Add(IObject obj) => Add(obj.item, obj.quantity);
    public void Add(ISlot slot) => Add(slot.item, slot.quantity);
    public ISlot Find(string name, out ISlot slot) => slot = slots.Find(s => s.item.name == name);
    public ISlot Find(string name, int quantity, out ISlot slot) => slot = slots.Find(s => s.item.name == name && s.quantity >= quantity);
    public bool Check(string name, int quantity) => Find(name, out ISlot slot) != null && slot.quantity >= quantity;
    public bool Remove(string name, int quantity)
    {
        if (Find(name, quantity, out ISlot slot) != null)
        {
            slot.quantity -= quantity;
            if (slot.Empty) slots.Remove(slot);
            ui.Synchronize();
            return true;
        }
        else return false;
    }

    public void RemoveAll(params IQuerry[] querries)
    {
        foreach (IQuerry querry in querries)
            Remove(querry.name, querry.quantity);
    }

    public bool Querry(params IQuerry[] querries)
    {
        foreach (IQuerry querry in querries)
            if (!Check(querry.name, querry.quantity))
                return false;
        return true;
    }

    [System.Serializable]
    public class ISlot
    {
        public IItem item;
        public int quantity;
        public bool Empty => quantity <= 0;

        public ISlot(IItem item, int quantity)
        {
            this.item = item;
            this.quantity = quantity;
        }
    }

    [System.Serializable]
    public class IQuerry
    {
        public string name;
        public int quantity;

        public IQuerry(string name, int quantity)
        {
            this.name = name;
            this.quantity = quantity;
        }
    }
}
