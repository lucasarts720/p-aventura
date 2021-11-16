using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IQuerry = IInventory.IQuerry;

[CreateAssetMenu]
public class IRecipe : ScriptableObject
{
    public IItem result;
    public IQuerry[] components;
}
