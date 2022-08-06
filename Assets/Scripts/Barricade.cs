using System;
using UnityEngine;

public class Barricade : MonoBehaviour
{
   private void OnTriggerEnter2D(Collider2D col)
   {
      if (col.gameObject.TryGetComponent(out BulletController bulletController))
      {
         Destroy(col.gameObject);
      }
   }
}
