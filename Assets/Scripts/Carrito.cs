using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Carrito : MonoBehaviour
{
    public LIstInventory list;
    [SerializeField] ItemData item, item2, item3, item4, item5, item6, item7, item8; // Añade más ítems según tus necesidades
    public TextMeshProUGUI textReceipt; // Campo de texto para mostrar la boleta
    public bool isbroken;
    public int limitMoney = 1500, money = 1500;
    //public GameObject salida;
    private float totalCost = 0f; // Variable para almacenar el costo total
    private List<ItemData> itemsInCart = new List<ItemData>(); // Lista para almacenar los ítems en el carrito

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Item"))
        {
            AddItemToCart(item);
        }
        else if (other.gameObject.CompareTag("Item2"))
        {
            AddItemToCart(item2);
        }
        // Añade más condiciones para Item3, Item4, etc. según tus necesidades
        else if (other.gameObject.CompareTag("Item3")) 
        { 
            AddItemToCart(item3);
        }
        else if (other.gameObject.CompareTag("Item4"))
        {
            AddItemToCart(item4);
        }
        else if (other.gameObject.CompareTag("Item5"))
        {
            AddItemToCart(item5);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Item"))
        {
            RemoveItemFromCart(item);
        }
        else if (other.gameObject.CompareTag("Item2"))
        {
            RemoveItemFromCart(item2);
        }
        else if (other.gameObject.CompareTag("Item3")) 
        { 
            RemoveItemFromCart(item3);
        } 
        else if (other.gameObject.CompareTag("Item4"))  
        { 
            RemoveItemFromCart(item4); 
        } 
        else if (other.gameObject.CompareTag("Item5")) 
        { 
            RemoveItemFromCart(item5); 
        }
        // Añade más condiciones para Item3, Item4, etc. según tus necesidades
    }

    private void AddItemToCart(ItemData item)
    {
        itemsInCart.Add(item);
        list.item.Add(item.itemName);
        totalCost += item.price;
        UpdateReceipt();
        Pay();
    }

    private void RemoveItemFromCart(ItemData item)
    {
        itemsInCart.Remove(item);
        list.item.Remove(item.itemName);
        totalCost -= item.price;
        UpdateReceipt();
    }

    private void UpdateReceipt()
    {
        string receiptText = "Boleta:\n";
        foreach (ItemData item in itemsInCart)
        {
            receiptText += $"{item.itemName}: ${item.price.ToString("F2")}\n";
        }
        receiptText += $"Total: ${totalCost.ToString("F2")}";
        textReceipt.text = receiptText;
    }

    public void Pay()
    {
        if (totalCost > limitMoney)
        {
            isbroken = true;
            Debug.Log("Esto no se vende, límite de dinero excedido");
            //salida.SetActive(false);
        }
        else
        {
            isbroken = false;
            Debug.Log("Se puede vender");
            //salida.SetActive(true);
        }
    }
}






