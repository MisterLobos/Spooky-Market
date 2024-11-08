using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Carrito : MonoBehaviour
{
    public LIstInventory list;
    [SerializeField] ItemData PLatano, Cebolla, Queso, Loncha, pi�a, Pimenton; // A�ade m�s �tems seg�n tus necesidades
    public TextMeshProUGUI textReceipt, textPaymentStatus; // Campo de texto para mostrar la boleta
    public bool isbroken;
    public int limitMoney = 1500, money = 1500;
    public GameObject salida;
    private float totalCost = 0f; // Variable para almacenar el costo total
    private List<ItemData> itemsInCart = new List<ItemData>(); // Lista para almacenar los �tems en el carrito

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Platano"))
        {
            AddItemToCart(PLatano);
        }
        else if (other.gameObject.CompareTag("Cebolla"))
        {
            AddItemToCart(Cebolla);
        }
        // A�ade m�s condiciones para Item3, Item4, etc. seg�n tus necesidades
        else if (other.gameObject.CompareTag("Queso")) 
        { 
            AddItemToCart(Queso);
        }
        else if (other.gameObject.CompareTag("Loncha"))
        {
            AddItemToCart(Loncha);
        }
        else if (other.gameObject.CompareTag("Pi�a"))
        {
            AddItemToCart(pi�a);
        }
        else if (other.gameObject.CompareTag("Pimenton"))
        {
            AddItemToCart(Pimenton);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Platano"))
        {
            RemoveItemFromCart(PLatano);
        }
        else if (other.gameObject.CompareTag("Cebolla"))
        {
            RemoveItemFromCart(Cebolla);
        }
        else if (other.gameObject.CompareTag("Queso")) 
        { 
            RemoveItemFromCart(Queso);
        } 
        else if (other.gameObject.CompareTag("Loncha"))  
        { 
            RemoveItemFromCart(Loncha); 
        } 
        else if (other.gameObject.CompareTag("Pi�a")) 
        { 
            RemoveItemFromCart(pi�a); 
        }
        else if (other.gameObject.CompareTag("Pi�a"))
        {
            RemoveItemFromCart(Pimenton);
        }
        // A�ade m�s condiciones para Item3, Item4, etc. seg�n tus necesidades
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
            Debug.Log("Esto no se vende, l�mite de dinero excedido");
            //salida.SetActive(false);
            textPaymentStatus.text = "L�mite de dinero excedido. No se puede realizar la compra."; 
            salida.SetActive(false);
        }
        else
        {
            isbroken = false;
            Debug.Log("Se puede vender");
            textPaymentStatus.text = "Compra realizada con �xito."; salida.SetActive(true);
            //salida.SetActive(true);
        }
    }
}






