using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class SliderPanel : MonoBehaviour,IDragHandler//,IEndDragHandler
{

    public Vector2 offset,start_coord,current_coord;
    public RectTransform rect_transform;
    public Canvas canvas;
   
    public void OnDrag(PointerEventData eventData)
    {
     Vector2 my_delta = new Vector2(0,eventData.delta.y);
     rect_transform.anchoredPosition+=my_delta/canvas.scaleFactor;

     if(rect_transform.anchoredPosition.y<-600) rect_transform.anchoredPosition= new Vector2(rect_transform.anchoredPosition.x,-600);
     if(rect_transform.anchoredPosition.y>0) rect_transform.anchoredPosition= new Vector2(rect_transform.anchoredPosition.x,0);
     
      
    }
    
    
    // Start is called before the first frame update
    void Start()
    {
         rect_transform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
