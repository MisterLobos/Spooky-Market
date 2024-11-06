using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ScriptableMenu", menuName = "ScriptableObjects/ItemData")]
public class ItemData : ScriptableObject
{
    [SerializeField] public string itemName; // Nombre del �tem
    [SerializeField] public GameObject prefab; // Prefab del �tem
    [SerializeField] public float price; // Precio del �tem
}
