using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkerNPCBihaviour : MonoBehaviour
{
    public int current_point_id=1;
   
    public float distance_to_current_point,minimum_distance=1f;
    public List<GameObject> path;
    public float walk_speed=1f;

    // Start is called before the first frame update
    void Start()
    {   
        var path_parent = GameObject.Find("WalkersPath1");
        foreach (Transform child in path_parent.transform)
        {
                path.Add(child.gameObject);
        }

    }

    // Update is called once per frame
    void Update()
    {
        var normalized_position = path[current_point_id].transform.position;
        normalized_position.y = transform.position.y;
        distance_to_current_point = Vector3.Distance(transform.position, normalized_position);
        if (distance_to_current_point <= minimum_distance) current_point_id++;
        if (current_point_id <= path.Count)
        {
           
            
            transform.LookAt(normalized_position);
            transform.position += transform.forward*Time.deltaTime*walk_speed;
           
        }
        if (current_point_id == path.Count) Destroy(gameObject);

    }
}
