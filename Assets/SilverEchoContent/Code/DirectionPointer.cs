using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionPointer : MonoBehaviour
{
     Camera cam_to_copy;
    public bool copy_from_main_camera;
    // Start is called before the first frame update
    void Start()
    {
      if(copy_from_main_camera)  cam_to_copy = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        var y_angle = cam_to_copy.transform.eulerAngles.y;
        var my_angle = new Vector3(0, y_angle, 0);
        transform.eulerAngles = my_angle;
    }
}
