using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Move : MonoBehaviour
{
    public Rigidbody rb;
    public float RayDistance, sensibilidad = 300f, velocidad;
    public LayerMask GrabLayer;
    public bool GrabObject;
    public GameObject GrabbedObject;
    public Transform PlayerHand;
    public Camera PlayerCamera;
    public LIstInventory list;
    //public ItemData item;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(PlayerCamera.transform.position, PlayerCamera.transform.forward * RayDistance, Color.red);
        Physics.Raycast(PlayerCamera.transform.position, PlayerCamera.transform.forward, out RaycastHit hiT, RayDistance, GrabLayer);
        if (Input.GetKeyDown(KeyCode.E))
        {
            //Debug.Log("estoy funcionando");
            if (GrabbedObject == null)
            {
                if (hiT.transform != null)
                {
                    GrabbedObject = hiT.transform.gameObject;
                    GrabbedObject.transform.SetParent(PlayerHand);
                    GrabbedObject.transform.localPosition = Vector3.zero;
                    GrabbedObject.GetComponent<Rigidbody>().isKinematic = true;



                }

            }
            else
            {
                GrabbedObject.transform.SetParent(null);
                GrabbedObject.GetComponent<Rigidbody>().isKinematic = false;
                GrabbedObject = null;


            }
        }

        float mouseX = Input.GetAxis("Mouse X") * sensibilidad * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensibilidad * Time.deltaTime;
        transform.Rotate(0, mouseX, 0);
        PlayerCamera.transform.Rotate(-mouseY, 0, 0);

        transform.Translate(Input.GetAxis("Horizontal") * velocidad * Time.deltaTime, 0, Input.GetAxis("Vertical") * velocidad * Time.deltaTime);
        //

        

    }


    public void Quit()
    {
        Application.Quit();
        Debug.Log("SE PUEDE SALIR");
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Salida"))
        {
            Quit();
            Debug.Log("se puede salir");
        }
    }

}
