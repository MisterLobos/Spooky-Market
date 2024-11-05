using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Carrito : MonoBehaviour
{

    public LIstInventory list;
    [SerializeField] ItemData item, item2, item3, item4;
    public TextMeshProUGUI Text1, text2, textCostTotal;
    public bool isbroken;
    public int limitMoney = 1500, money;
    public GameObject salida;

    private void OnTriggerEnter(Collider other)
    {
        // Revisa si el objeto tiene el tag "Item" o "Item2" y realiza las acciones adecuadas
        if (other.gameObject.CompareTag("Item"))
        {
            list.item.Add(item.itemName); // Añade el nombre del primer item a la lista
            UpdateUI(item);
            Pay();
        }
        else if (other.gameObject.CompareTag("Item2"))
        {
            list.item.Add(item2.itemName); // Añade el nombre del segundo item a la lista
            UpdateUI(item2);
            Pay();
        }
        else if (other.gameObject.CompareTag("Item3"))
        {
            list.item.Add(item3.itemName); // Añade el nombre del tercer item a la lista
            UpdateUI(item3);
            Pay();
        }
        else if (other.gameObject.CompareTag("Item4"))
        {
            list.item.Add(item4.itemName); // Añade el nombre del cuarto item a la lista
            UpdateUI(item4);
            Pay();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Elimina el item que ha salido del carrito y actualiza el UI
        if (other.gameObject.CompareTag("Item"))
        {
            list.item.Remove(item.itemName);
            ClearUI();
        }
        else if (other.gameObject.CompareTag("Item2"))
        {
            list.item.Remove(item2.itemName);
            ClearUI();
        }
        else if (other.gameObject.CompareTag("Item3"))
        {
            list.item.Remove(item3.itemName);
            ClearUI();
        }
        else if (other.gameObject.CompareTag("Item4"))
        {
            list.item.Remove(item4.itemName);
            ClearUI();
        }
    }

    
    private void UpdateUI(ItemData itemData)
    {
        Text1.text = itemData.itemName;
        text2.text = itemData.itemPrice.ToString(); 
    }

    
    private void ClearUI()
    {
        Text1.text = null;
        text2.text = null;
    }


    public void Pay()
    {
        if (money > limitMoney) 
        {
            isbroken = true;
            print("Esto no se puede vender, límite de dinero excedido");
            salida.SetActive(false); 
        }
        else
        {
            isbroken = false;
            print("Se puede vender");
            salida.SetActive(true);
        }
    }


}


    