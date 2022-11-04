using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomLOD : MonoBehaviour
{
    public float dist, min_dist;
    public GameObject cam;
    public Renderer[] vision;
    public bool isHide;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main.gameObject;
        vision = transform.GetComponentsInChildren<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        dist = Vector3.Distance(cam.transform.position, transform.position);
        isHide = dist > min_dist;
        if (vision.Length > 0) 
        {
            var first_element_state = vision[0].enabled;
            if (isHide == true)
            {
                if (first_element_state == true)
                {
                    foreach (var x in vision)
                    {
                        x.enabled = false;
                    }
                }
            }
            else 
            {
                if (first_element_state == false) 
                {
                    foreach (var x in vision)
                    {
                        x.enabled = true;
                    }
                }
            }
        }
    }
}
