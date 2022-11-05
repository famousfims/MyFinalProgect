using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheckerBihaviour : MonoBehaviour
{
    public bool is_grounded;
    public RaycastHit hit;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        is_grounded = Physics.Raycast(transform.position, Vector3.down, out hit,1f);

    }
}
