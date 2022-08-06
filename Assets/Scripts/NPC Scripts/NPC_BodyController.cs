using UnityEngine;
[RequireComponent(typeof(BoxCollider2D))]
public class NPC_BodyController : MonoBehaviour
{
  private void OnTriggerEnter2D(Collider2D col)
   {
      if (col.gameObject.TryGetComponent(out BulletController bulletController))
      {
         Destroy(col.gameObject);
         Destroy(gameObject.transform.parent.gameObject);
      }
   }
}
