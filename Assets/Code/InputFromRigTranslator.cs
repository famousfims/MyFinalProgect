using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputFromRigTranslator : MonoBehaviour
{

    
    public PlayerBallContoller ball_player_controller;



    [Header("Sensor Input Links")]
    public VirtualTachPad ball_movement_touchpad;
    public VirtualTachPad camera_movement_touchpad;


    public void SendRotateRequest() 
    {
        Vector2 rotate_direction = camera_movement_touchpad.pixel_delta;
        ball_player_controller.ball_camera_system.RotateByX(rotate_direction.y);
        ball_player_controller.ball_camera_system.RotateByY(rotate_direction.x);


    }

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
       
        SendRotateRequest();
    }
}
