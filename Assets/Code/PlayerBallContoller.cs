using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBallContoller : MonoBehaviour
{
    public BallMovement ball_movement_system;
    public CameraRotator ball_camera_system;


   
  



    public void RequestJumpFromControlledBall() 
    {
        ball_movement_system.MakeJump();
    }


    public void RequestRotateCameraFromControlledBall(float rotate_y_delta) 
    {
        ball_camera_system.RotateByY(rotate_y_delta * Time.deltaTime);
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
