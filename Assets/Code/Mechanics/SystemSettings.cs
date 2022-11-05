using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemSettings : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void SetScreenHalfHD()
    {
        Screen.SetResolution(848, 480,true);

        GameObject.Find("Player").GetComponent<PlayerControll>().swipe_speed = 4;

    }
    public void SetScreenHD()
    {
        Screen.SetResolution(1280, 720,true);
        GameObject.Find("Player").GetComponent<PlayerControll>().swipe_speed = 2;
    }
    public void SetScreenFHD()
    {
        Screen.SetResolution(1920, 1080,true);

        GameObject.Find("Player").GetComponent<PlayerControll>().swipe_speed = 1;
    }
    public void SetShadowResolution(int level)
    {
        var component = GameObject.Find("Directional Light").GetComponent<Light>();
        switch (level) 
        {
            case 1:
                component.shadowResolution = UnityEngine.Rendering.LightShadowResolution.VeryHigh;
                break;
            case 2:
                component.shadowResolution = UnityEngine.Rendering.LightShadowResolution.Medium;
                break;
            case 3:
                component.shadowResolution = UnityEngine.Rendering.LightShadowResolution.Low;
                break;
        }
         
    }
    public void ToogleShadows(int value) 
    {
        var component = GameObject.Find("Directional Light").GetComponent<Light>();
        if (value == 1) 
        {
            component.shadows =LightShadows.Soft;
        }
        if (value == 0)
        {
            component.shadows = LightShadows.None;
        }

    }





    // Update is called once per frame
    void Update()
    {
        
    }
}
