using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
   private void FixedUpdate()
   {
      transform.Rotate(Vector3.up,Space.World); 
   }
}
