using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepSoundPlayer : MonoBehaviour
{
    public AudioClip footstep1, footstep2;
    public AudioSource source;
    public int foot_id;
    // Start is called before the first frame update
    void Start()
    {
        source = gameObject.AddComponent<AudioSource>();
    }
    public void PlayFootstep() 
    {
        if (foot_id == 0) source.PlayOneShot(footstep1);
        else source.PlayOneShot(footstep2);
        foot_id=    foot_id== 0 ? 1 : 0;

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
