using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ScripteableMenu", menuName = "ScripteableObjects")]
public class ItemData : ScriptableObject
{
    public int  price;
    public string itemName;
    public GameObject prefab;
}
