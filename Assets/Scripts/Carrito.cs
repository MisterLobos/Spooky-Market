using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Carrito : MonoBehaviour
{

    public LIstInventory list;
    [SerializeField] ItemData item;




    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Item"))
        {
            list.item.Add(item.itemName);
            print("hola");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        list.item.Remove(item.itemName);
        print("adios");
    }
}


    