using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NatureLOD : MonoBehaviour
{
    public Animator anim;
   
    public float min_optimize_distance;



    public Renderer spriter;
    public float curent_distance;
    Camera camera_cull_from;
    public bool is_optimized;


    // Start is called before the first frame update
    void Start()
    {
        camera_cull_from = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        curent_distance = Vector3.Distance(transform.position, camera_cull_from.transform.position);
        is_optimized = curent_distance >= min_optimize_distance;
        anim.SetBool("Is Optimized", is_optimized);
      




       
        if (is_optimized) 
        {
            var prevAngles = spriter.transform.eulerAngles;
            spriter.transform.LookAt(camera_cull_from.transform.position);
            prevAngles.y = spriter.transform.eulerAngles.y;
            spriter.transform.eulerAngles = prevAngles;
        }


        

    }
}
