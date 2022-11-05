using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationController : MonoBehaviour
{
    [HideInInspector]
 
    public Animator anim;
    public CharacterMovement movement_system;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

       // anim.SetBool("IsGrounded", movement_system.is_grounded);
       // anim.SetBool("Running", movement_system.is_moving);

//        if (main_scr.isRunning)  anim.speed = 2;  else anim.speed = 1;
       
//        if(GetAndTrow.isHandling) anim.SetLayerWeight(1, 0); else anim.SetLayerWeight(1, 1);

    }
}
