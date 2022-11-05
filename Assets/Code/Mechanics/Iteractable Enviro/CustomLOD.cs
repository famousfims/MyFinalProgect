using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomLOD : MonoBehaviour
{
    public List<GameObject> childrens;
    public float cull_distance, current_distance;
    public bool is_culled;


    // Start is called before the first frame update
    void Start()
    {
        is_culled = current_distance < cull_distance;


        foreach (Transform child in transform) 
        {
            childrens.Add(child.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        current_distance = Vector3.Distance(transform.position, Camera.main.transform.position);

     
        if (is_culled != (current_distance < cull_distance))
        {
            is_culled = !is_culled;
            foreach (GameObject child in childrens) { child.SetActive(is_culled); }
        }
      


    }
}
