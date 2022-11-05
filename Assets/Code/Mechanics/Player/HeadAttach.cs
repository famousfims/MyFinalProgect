using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadAttach : MonoBehaviour
{
    public GameObject head_origin;
    public Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = head_origin.transform.position+transform.TransformDirection(offset);


        float head_x= -transform.eulerAngles.x-180, head_y=transform.eulerAngles.y+180, head_z=transform.eulerAngles.z+90;



        head_origin.transform.eulerAngles = new Vector3(head_x, head_y, head_z);
    }
}
