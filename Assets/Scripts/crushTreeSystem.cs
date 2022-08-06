using UnityEngine;

public class crushTreeSystem : MonoBehaviour
{
    [SerializeField] private Sprite crushedTree;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.TryGetComponent(out BulletController bc) ||
            col.gameObject.TryGetComponent(out PlayerProperties pp) ||
            col.gameObject.TryGetComponent(out NPC_BodyController npc))
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = crushedTree;
        }
    }
}
