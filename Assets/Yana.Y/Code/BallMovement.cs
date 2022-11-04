using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public Rigidbody ball_rigidbody;
    public float move_speed;
    public float horizontal;
    public float vertical;
    public Vector3 direction_and_speed;
    public float jump_force;
    public Transform direction_pointer;
    public GroundCheckerBihaviour ground_checker_system;


     public void MoveByCamera(Vector3 local_direction) 
    {
        var transformed_direction = direction_pointer.TransformDirection(local_direction);

        ball_rigidbody.AddForce(transformed_direction * move_speed);
    }
    public void MakeJump()
    {
      if(ground_checker_system.is_grounded) ball_rigidbody.AddForce(Vector3.up* jump_force);

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }
    void FixedUpdate()
    {
        ball_rigidbody.AddForce(direction_and_speed* move_speed);
    }
    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        
        direction_and_speed.x = horizontal;
        direction_and_speed.y = 0;
        direction_and_speed.z = vertical;

    }
}
