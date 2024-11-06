using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PriceDisplay : MonoBehaviour
{
    public ItemData itemData;

    public Text priceText;  
    // Start is called before the first frame update
    void Start()
    {
        if(priceText !=null)
        {
            priceText.text = "Precio: $" + itemData.price.ToString("F2");   
        }
        else
        {
            Debug.LogError("El componente no esta assignado");
        }
        
    }

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Carrtito")
        {
            itemData.price += 10.0f;
            priceText.text = "precio $" + itemData.price.ToString("F2"); 
        }
    }
}
