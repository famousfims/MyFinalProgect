using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotator : MonoBehaviour
{
    public float rotation_y_sens;
    public float rotation_x_sens;
    
    public float x_min_clamp, x_max_clamp;
    public float curent_x_angle;


    public void RotateByY(float angle) 
    {
        var angles = transform.eulerAngles;
        angles.y += angle*rotation_y_sens;
        transform.localEulerAngles = angles;

    }
    public void RotateByX(float angle)
    {
        var prediction_x = curent_x_angle - angle * rotation_x_sens;
        if (prediction_x > x_min_clamp && prediction_x < x_max_clamp) 
        {
            curent_x_angle = prediction_x;
        }
        var angles = transform.localEulerAngles;
        angles.x = curent_x_angle;
        transform.localEulerAngles = angles;


    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
