using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallAttacher : MonoBehaviour
{
    public GameObject ball;
    public Vector3 offset;


    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Update()
    {
        transform.position = ball.transform.position + offset;
    }

    private void LateUpdate()
    {
       // transform.position = ball.transform.position + offset;
    }
    // Update is called once per frame
    
}
