using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerRigPicker : MonoBehaviour
{
    
    public GameObject current_rig;


    public GameObject touch_screen_rig;


    private void Awake()
    {
        
            touch_screen_rig.SetActive(true);
            current_rig = touch_screen_rig;
       
       
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
