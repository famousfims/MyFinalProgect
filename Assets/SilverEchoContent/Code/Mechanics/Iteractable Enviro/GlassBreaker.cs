using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassBreaker : MonoBehaviour
{

    public GameObject glassShards_VFX;
    

    // Start is called before the first frame update
    void Start()
    {
        transform.tag = "CanPickUp";   
    }
    private void OnCollisionEnter(Collision collision)
    {
       // print(collision.gameObject.name);
        if (collision.gameObject.tag == "Glass") 
        {
            Destroy(collision.gameObject);
            Destroy( Instantiate(glassShards_VFX, transform.position, transform.rotation),10f);
           
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
