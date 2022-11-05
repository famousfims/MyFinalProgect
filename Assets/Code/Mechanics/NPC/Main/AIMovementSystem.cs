using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public delegate void NPCcharacterHasComeEvent();
public class AIMovementSystem : MonoBehaviour
{

    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private bool is_can_move;
    [SerializeField] private Transform destination_point;
    [SerializeField] private float distance_to_destinationPoint;
    [SerializeField] private float minimum_come_distance_treshold;


    [SerializeField] public bool is_come;



    /***************Setters and Getters**********/
    public Transform Destination_Point { get => destination_point; set => destination_point = value; }
    public bool Is_Can_Move { get => is_can_move; set => is_can_move = value; }


    /*************** Funcs**********/
    private void MoveToDestination() 
    {
        agent.SetDestination(Destination_Point.position);
    }
    

    void Update()
    {
        if (destination_point != null) //якщо нам сказали куди рухатись  
        {
            distance_to_destinationPoint = Vector3.Distance(transform.position, destination_point.position); //взнаэмо дистанцію
        }
                        /****************/
        if (Is_Can_Move && destination_point != null) // якщо  можемо рухатись, і маємо куди 
        {
            MoveToDestination();// починаємо рухатись.
        }

        /******************/

        if (distance_to_destinationPoint <= minimum_come_distance_treshold)
        {
            if (is_come == false)
            {
                is_come = true;
                destination_point = null;
            }
        }
        else { is_come = false; }
    }
}
