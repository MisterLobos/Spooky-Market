using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Carrito : MonoBehaviour
{

    public LIstInventory list;
    [SerializeField] ItemData item;
    public TextMeshProUGUI Text1, text2, textCostTotal;
    public bool isbroken = true;
    public int limitMoney = 30, money;
  
    



    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Item"))
        {
            list.item.Add(item.itemName);
            //print("hola");
            Text1.text = item.itemName ;
            text2.text = item.itemPrice;
            money = item.price;
            Pay();
             
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        list.item.Remove(item.itemName);
        Text1.text = null;
        text2.text = null;
        
    }

    public void Pay()
    {
        if (limitMoney > money)
        {
            isbroken = true;
            //gameObject.SetActive(true);
            print("esto no se vende");

        }
        else
        {
            isbroken = false;
            //gameObject.SetActive(false);
        }

    }
   
   
}


    