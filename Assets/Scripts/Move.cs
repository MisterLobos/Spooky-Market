using System.Collections;
using System.Collections.Generic;
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
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Debug.Log("estoy funcionando");
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

        float MouesX = Input.GetAxis("Mouse X") * sensibilidad * Time.deltaTime;
        float MouseY = Input.GetAxis("Mouse Y") * sensibilidad * Time.deltaTime;
        transform.Rotate(0, MouesX, 0);
        PlayerCamera.transform.Rotate(-MouseY, 0, 0);

        transform.Translate(Input.GetAxis("Horizontal") * velocidad * Time.deltaTime, 0, Input.GetAxis("Vertical") * velocidad * Time.deltaTime);

    }
}
