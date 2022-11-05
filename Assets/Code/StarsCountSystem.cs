using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StarsCountSystem : MonoBehaviour
{


    public TextMeshProUGUI text_display;
    public int stars_count;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        text_display.text = stars_count.ToString();
    }
}
