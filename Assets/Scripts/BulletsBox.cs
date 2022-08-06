using UnityEngine;
[RequireComponent(typeof(BoxCollider2D))]
public class BulletsBox : MonoBehaviour
{
    [SerializeField] private int bulletsAvaibleInBox;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.TryGetComponent(out PlayerProperties _playerProperties))
        {
            _playerProperties.BulletsAvailable += bulletsAvaibleInBox;
            Destroy(gameObject);
        }
    }
}