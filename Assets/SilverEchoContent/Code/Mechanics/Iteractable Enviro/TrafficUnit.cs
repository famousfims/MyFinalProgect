using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficUnit : MonoBehaviour
{
    public GameObject[] points;
    public int current_point_index=0;
    public float distance_to_current;
    public float move_speed=10f;
    public float max_move_speed = 10f;

    public bool see_obstacle;


    [Header("Sounds")]
    public AudioClip[] horns;
    public float signal_cd;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void CheckForward()
    {
        RaycastHit hit;
        if (Physics.SphereCast(transform.position, 3f, transform.forward, out hit, 5f)) 
        { 
            if (hit.collider.tag == "Player" || hit.collider.tag == "TrafficUnit") see_obstacle = true; 
            else see_obstacle = false;
        }
        else see_obstacle = false;




    }
    // Update is called once per frame
    void Update()
    {
        CheckForward();

        if (!see_obstacle)
        {

            move_speed += 1 * Time.deltaTime;// �������� ��������
            if (move_speed > max_move_speed) move_speed = max_move_speed; // ������ ����������� ��������
            //  ���� �� ����� �� ��������� �����, ���������� ������.
            if (current_point_index == points.Length - 1) Destroy(gameObject);



            // ������ ���������� � ����� ����������  
            distance_to_current = Vector3.Distance(points[current_point_index].transform.position, transform.position);
            //  ************************
            //  ���� ��������� � ����� ���������, �.�. �� ������, ���� � ��������� �����.
            if (distance_to_current < 1f)
            {
                current_point_index++;
            }





            // ��������������� �� ����� � ����������� "������" 
            transform.position += transform.forward * move_speed * Time.deltaTime;
            //  ********************
            // TODO 
            // ���� ����� ����� ����� � ���������� 4 ������ - ��������������� � ��������


            //  ������ ������� � ������ ����� 
            var targetRotation = Quaternion.LookRotation(points[current_point_index].transform.position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, move_speed * Time.deltaTime);
            //  ************************* //  
        }
        else
        {
            move_speed = 0;
            signal_cd -= Time.deltaTime;
            if (signal_cd < 0)
            {
                var random_index = Random.Range(0, horns.Length);
                GetComponent<AudioSource>().PlayOneShot(horns[random_index]);
                signal_cd = Random.Range(0.5f, 0.7f);
            }

        }
    }
}
