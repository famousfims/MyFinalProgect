using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrainSystem : MonoBehaviour
{
    [Header("System Links")]
    [SerializeField] private AIMovementSystem movement_system;
    [SerializeField] private Animator animation_system;
    [SerializeField] private EyesSystem eyes_system;
    


    [Header("State vars")]
    [SerializeField] private bool is_in_stun;
    [SerializeField] private bool is_in_agression;
    [SerializeField] private bool is_in_desire_sleep;


    [Header("Agression vars")]
    [SerializeField] private GameObject player_object;
    [SerializeField] private float chill_from_agression_time;
    [SerializeField] private float min_distance_for_chill_from_agression;
    [SerializeField] private float current_distance_to_player;

    [Header("Desire vars")]
    public Desire[] desire_list;
    public Desire current_desire;
    public float last_seconds_to_sleep;
    public bool is_desire_satisfided;
        
    public GameObject Player_Object { get => player_object; set => player_object = value; }

    public void RandomizeNewDesire() 
    {
        current_desire = desire_list[Random.Range(0, desire_list.Length)];
    }

    void RefreshRealtimeInfo() { }
    public void DesireBrunch() 
    {
        if (!is_desire_satisfided ) 
        {
            movement_system.Destination_Point = current_desire.transform;

            if (movement_system.is_come)
            {
                animation_system.SetBool("satisfy_desire", true);
                animation_system.SetInteger("desire_id",current_desire.desire_id);

            }
            else 
            {
                
                animation_system.SetBool("satisfy_desire", false);
            }

        }    

    }
    public void AgressionBrunch()
    {

    }
    




    // Start is called before the first frame update
    void Start()
    {
        RandomizeNewDesire();
    }

    // Update is called once per frame
    void Update()
    {
        RefreshRealtimeInfo();

        if (is_in_agression)
        {
            AgressionBrunch();
        }
        else 
        {
            DesireBrunch();
        }
    }
}
