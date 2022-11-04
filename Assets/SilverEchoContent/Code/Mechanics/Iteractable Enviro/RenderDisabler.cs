using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderDisabler : MonoBehaviour
{
    [SerializeField]
    private Renderer[] objectsToDisable;
    [SerializeField]
    private bool useDisabler;
    // Start is called before the first frame update
    void Start()
    {
        if (useDisabler)
        {
            foreach (var obj in objectsToDisable)
            {
                obj.enabled = false;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
