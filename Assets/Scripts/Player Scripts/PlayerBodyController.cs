using UnityEngine;
[RequireComponent(typeof(BoxCollider2D))]
public class PlayerBodyController : MonoBehaviour
{
    private GameObject mainPlayerObject;
    private PlayerProperties _playerProperties;
    void Start()
    {
         mainPlayerObject = transform.parent.gameObject;
         _playerProperties = mainPlayerObject.GetComponent<PlayerProperties>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.TryGetComponent(out BulletController _bulletController))
        {
            _playerProperties.AvailableHealth -= _bulletController.thisBulletDamage;
            Destroy(col.gameObject);
        }
    }
}
