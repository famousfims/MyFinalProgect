using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class AnimationEventsCallbackSender : MonoBehaviour
{
    public UnityEvent OnAnimationEventTriggered;



    [Header("Attachment Vars")]
    public GameObject coffe_cup_object;
    public GameObject watering_can_object;


    public void Coffe_Turn_On() 
    {
        coffe_cup_object.SetActive(true);
    }
    public void Coffe_Turn_Off()
    {
        coffe_cup_object.SetActive(false);
    }
    public void Watering_can_Turn_On()
    {
        watering_can_object.SetActive(true);
    }
    public void Watering_can_Turn_Off()
    {
        watering_can_object.SetActive(false);
    }





    public void TriggerEvent() 
    {
        OnAnimationEventTriggered.Invoke();
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
