using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class IItem : ScriptableObject
{
    public new string name;
    [TextArea(3, 5)] public string description;
    public Sprite icon;
    public bool stackable;
    public string meta;
}
