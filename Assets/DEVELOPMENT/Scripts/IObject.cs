using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IObject : MonoBehaviour
{
    public new string name;
    [TextArea(3, 5)] public string description;
    public Sprite icon;
    public int quantity;
    public bool stackable;
    public string meta;
}
