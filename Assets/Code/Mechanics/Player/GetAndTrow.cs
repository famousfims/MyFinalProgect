using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetAndTrow : MonoBehaviour
{
    public GameObject socket,socket_position;
    public float minimum_grab_distance = 4f;
    public float trow_force;
    public bool may_take;
    public static bool isHandling;
    GameObject grab_button; 
    // Start is called before the first frame update
    void Start()
    {
     grab_button = GameObject.Find("GrabButton");
    }

    // Update is called once per frame
    public void GrabItem()
    {

        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            var rb = hit.collider.gameObject.GetComponent<Rigidbody>();
            if (rb != null)
            {

                socket = rb.gameObject;
            }
        }
    }
    public void TrowItem() 
    {   var temp_socket = socket;
        if (socket != null) 
        {
            socket = null;
            temp_socket.GetComponent<Rigidbody>().isKinematic = false;
            temp_socket.GetComponent<Collider>().enabled = true;
            temp_socket.GetComponent<Rigidbody>().velocity = Camera.main.transform.forward * trow_force;
            
        }
    }
    private void LateUpdate()
    {
        if (socket != null)
        {
            socket.transform.position = socket_position.transform.position;
            socket.transform.rotation = socket_position.transform.rotation;

            if (socket.GetComponent<Collider>().enabled == true) socket.GetComponent<Collider>().enabled = false;
            if (socket.GetComponent<Rigidbody>().isKinematic == true) socket.GetComponent<Rigidbody>().isKinematic = false;
        }
    }
    void Update()
    {
        isHandling = socket == null;
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            var rb = hit.collider.gameObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                var dist = Vector3.Distance(transform.position, rb.gameObject.transform.position);
                if (dist < minimum_grab_distance)
                {
                    may_take = true;
                }
                else 
                {
                    may_take = false;
                }
            }
            else
            {
                may_take = false;
            }
        }
        else 
        {
            may_take = false;
        }

        if (socket != null) may_take = false;


        if ( may_take  )
        {
            if(grab_button.activeInHierarchy == false)grab_button.SetActive(true);
        }
        else
        {
            if (grab_button.activeInHierarchy == true) grab_button.SetActive(false);

        }
     

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (socket == null)
            {
                GrabItem();
            }
            else
            {
                TrowItem();
            }
        }
    }
}
