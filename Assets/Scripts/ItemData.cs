using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ScriptableMenu", menuName = "ScriptableObjects/ItemData")]
public class ItemData : ScriptableObject
{
    [SerializeField] public string itemName; // Nombre del ítem
    [SerializeField] public GameObject prefab; // Prefab del ítem
    [SerializeField] public float price; // Precio del ítem
}
