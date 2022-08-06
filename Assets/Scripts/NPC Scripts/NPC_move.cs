using UnityEngine;
[RequireComponent(typeof(Rigidbody2D), typeof(NPC_Properties))]
public class NPC_move : MonoBehaviour
{
    private NPC_Properties _properties;
    [SerializeField] private float minTimeToChange, maxTimeToChange;
    private float exitTime;
    private Vector2 MoveDirection;
    private Rigidbody2D _rigidbody2d;
    [SerializeField] private float additionalTextureAngle;
    void Start()
    {
        _properties = gameObject.GetComponent<NPC_Properties>();
        _rigidbody2d = gameObject.GetComponent<Rigidbody2D>();
        GenerateTimerAndDirection();
    }

    void Update()
    {
        exitTime -= Time.deltaTime;
        if (exitTime <= 0)
        {
            GenerateTimerAndDirection();
        }

        _rigidbody2d.velocity = MoveDirection * _properties.speed;
    }

    void GenerateTimerAndDirection()
    {
        exitTime = Random.Range(minTimeToChange, maxTimeToChange);
        MoveDirection = new Vector2(Random.Range(-180f, 180f), Random.Range(-180f, 180f)).normalized;
        RotateToAngle();
    }

    void RotateToAngle()
    {
        gameObject.transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(MoveDirection.y, MoveDirection.x) * Mathf.Rad2Deg + additionalTextureAngle);
        
    }
}
