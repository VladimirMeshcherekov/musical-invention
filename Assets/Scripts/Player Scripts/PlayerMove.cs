using UnityEngine;
[RequireComponent(typeof(Rigidbody2D), typeof(PlayerProperties))]

public class PlayerMove : MonoBehaviour
{ 
   private Rigidbody2D _rigidbody2d;
   [SerializeField] private FixedJoystick _moveJoystick;
   private PlayerProperties _playerProperties;
   [SerializeField] private float _textureRotate;
    void Start()
    {
        _rigidbody2d = gameObject.GetComponent<Rigidbody2D>();
        _playerProperties = gameObject.GetComponent<PlayerProperties>();
    }
    
    void Update()
    {
        if (_moveJoystick.Horizontal != 0 || _moveJoystick.Vertical != 0)
        {
            RotatePlayer();
            MovePlayer();
        }
    }

    void MovePlayer()
    {
          _rigidbody2d.velocity = new Vector2(_moveJoystick.Horizontal * _playerProperties.playerSpeed, _moveJoystick.Vertical * _playerProperties.playerSpeed);
    }

    void RotatePlayer()
    {
        float eulerAngle = Mathf.Atan2(_moveJoystick.Vertical, _moveJoystick.Horizontal) * Mathf.Rad2Deg;
        gameObject.transform.rotation = Quaternion.Euler(0, 0, eulerAngle + _textureRotate);
    }
}