using UnityEngine;
[RequireComponent(typeof(Rigidbody2D), typeof(BoxCollider2D))]
public class BulletController : MonoBehaviour
{
    [SerializeField] private float _bulletSpeed;
    [SerializeField] public float thisBulletDamage;
    private Vector2 _direction = new Vector2(0, 0);
    private Rigidbody2D _rigidbody2D;
    private float angle;
    
    void Start()
    {
        _rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
         _rigidbody2D.velocity = _direction * _bulletSpeed;
         gameObject.transform.rotation = Quaternion.Euler(0, 0, angle - 90);
    }

    public void GetDirection(Vector2 newDirection)
    {
        _direction = newDirection.normalized;
        angle = Mathf.Atan2(_direction.y, _direction.x) * Mathf.Rad2Deg;
    }
    
}
