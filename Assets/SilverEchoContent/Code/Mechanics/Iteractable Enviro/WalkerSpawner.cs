using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkerSpawner : MonoBehaviour
{
    public GameObject prefab;
    public float spawn_cd, spawn_timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        spawn_timer -= Time.deltaTime;
        if (spawn_timer <= 0) 
        {
            spawn_cd = Random.Range(30f, 60f);
            spawn_timer = spawn_cd;
            Instantiate(prefab, transform.position, transform.rotation);
        }
        
    }
}
