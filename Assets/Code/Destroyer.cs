using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
     public void DestroySelectedObject(GameObject object_to_destroy)
   {
       Destroy(object_to_destroy);

   }
}
