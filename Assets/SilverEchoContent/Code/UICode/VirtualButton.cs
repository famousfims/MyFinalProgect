using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class VirtualButton : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    public  bool is_pressed;
    public UnityEvent on_button_reales;
    public UnityEvent on_button_press;
    public UnityEvent on_button_long_press;
    public float long_tap;
    public float long_tap_cd=0.5f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (is_pressed) 
        {
            long_tap -= Time.deltaTime;
        }
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        is_pressed = true;
        long_tap = long_tap_cd;
        on_button_press.Invoke();
    }
    public void OnLongPointerUp() 
    {
        is_pressed = false;
        on_button_long_press.Invoke();
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        if (long_tap <= 0) 
        {
            OnLongPointerUp();
        }
        else 
        {
            is_pressed = false;

            on_button_reales.Invoke();
        }
       
    }
}
