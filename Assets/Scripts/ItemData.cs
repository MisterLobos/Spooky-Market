using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ScripteableMenu", menuName = "ScripteableObjects")]
public class ItemData : ScriptableObject
{
    [SerializeField]public int  price;
    [SerializeField]public string itemName;
    [SerializeField]public GameObject prefab;

}
