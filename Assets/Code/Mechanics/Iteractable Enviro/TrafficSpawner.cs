using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] points;
    public GameObject traffic_unit;
    public GameObject[] car_models;
    public float spawn_timer;

    public bool activate; // Ïåðåìåííàÿ ðåãóëèðóåòñÿ ñâåòîôîðîì. Åñëè îòêëþ÷åíà, òðàôèê ïåðåñòàåò ñïàâíèòñÿ


    //***************************************** //
    // Àëãîðèòì
    //1 Ñïàâíèòñÿ ïóñòîé îáüåêò
    //2 Â íåãî çàêèäûâàåì àíèìèðîâàííóþ ìîäåëü ìàøèíû
    //3 Ìàøèíà äâèãàåòñÿ ïî òî÷êàì, ïîêà íå äîéäåò äî ïîñëåäíåé
    //4 åñëè ïåðåä ìàøèíîé ÷òî òî åñòü, îíà îñòàíàâëèâàåòñÿ è ñèãíàëèò



    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (activate) 
        { 
            spawn_timer -= Time.deltaTime;
            if (spawn_timer <= 0)
                {
                    var unit = Instantiate(traffic_unit,transform.position,transform.rotation,null);
                    unit.GetComponent<TrafficUnit>().points = points;
                    //TODO Âñòàâêà 3Ä ìîäåëè â áîëâàíêó òðàôèêà
                    var unit_model = Instantiate(car_models[Random.Range(0, car_models.Length)], unit.transform);
                    unit_model.transform.localPosition = Vector3.zero;
                    unit_model.transform.eulerAngles= unit.transform.eulerAngles;


                //todo stuff
                spawn_timer = Random.Range(5f, 9f);
                }

        }


    }
}
