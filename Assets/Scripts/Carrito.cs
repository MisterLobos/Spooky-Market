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
    public int limitMoney = 15000, money;
    public GameObject salida;





    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Item"))
        {
            list.item.Add(item.itemName);
            //print("hola");
            Text1.text = item.itemName;
            text2.text = item.itemPrice;
            Pay();
            //textcosttotal;

        }
        if (other.gameObject.CompareTag("Item2"))
        {
            Text1.text = item2.itemName;
            text2.text = item2.itemPrice;
            
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
        if (limitMoney < money)
        {
            isbroken = true;
            //gameObject.SetActive(true);
            print("esto no se vende");
            salida.SetActive(false);


        }
        else
        {
            isbroken = false;
            //gameObject.SetActive(false);
            print("se puede vender");
            salida.SetActive(true);

        }

    }
   
   
}


    