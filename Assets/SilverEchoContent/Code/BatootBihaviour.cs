using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatootBihaviour : MonoBehaviour
{
    public float push_force;
    public AudioClip jump_sound_clip;
    public AudioSource source;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PlayerSphere") 
        {
            var rg = other.gameObject.GetComponent<Rigidbody>();
            rg.AddForce(Vector3.up*push_force);
            source.PlayOneShot(jump_sound_clip);
        }
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
