using UnityEngine;

public class CursoreController : MonoBehaviour
{
    [SerializeField] private float cursoreSpeed = 0.25f;
    [SerializeField] private FixedJoystick _fixedJoystick;
    private GameObject mainPlayerObject;
    
    private void Start()
    {
        mainPlayerObject = transform.parent.gameObject;
    }

    void Update()
    {
        // gameObject.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + new Vector3(0, 0, InputMouseDepth);
        gameObject.transform.position = new Vector3(transform.position.x + _fixedJoystick.Horizontal * cursoreSpeed,
           transform.position.y + _fixedJoystick.Vertical * cursoreSpeed, 0);

      gameObject.transform.rotation = Quaternion.Euler(0, 0, mainPlayerObject.transform.rotation.z * -1);
    }
}
