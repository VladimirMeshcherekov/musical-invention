using UnityEngine;

public class NPC_Logic : MonoBehaviour
{
    [SerializeField] float additionalTextureAngle;
    
    [Header("Shoot System")]
    [SerializeField] public GameObject findEnemy, cannon, bullet;
    [SerializeField] public Transform bulletSpawn;
    [SerializeField] private float CD;
    private float exitTime;
    private bool AbleToShoot = true;

    private void Start()
    {
        StartCDTimer();
    }

    void Update()
    {
        exitTime -= Time.deltaTime;
        if (exitTime <= 0)
        {
            AbleToShoot = true;
            StartCDTimer();
        }

        if (findEnemy != null)
        {
            rotateToEnemy(findEnemy, cannon);
            shoot(bullet);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out Player _thisEnemy))
        {
            findEnemy = other.gameObject;
            rotateToEnemy(findEnemy, cannon);
            shoot(bullet);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out Player _thisEnemy))
        {
            findEnemy = null;
        }
    }

    void rotateToEnemy(GameObject Enemy, GameObject Cannon)
    {
        float cursoreX = Enemy.transform.position.x;
        float cursoreY = Enemy.transform.position.y;

        float playerX = Cannon.transform.position.x;
        float playerY = Cannon.transform.position.y;

        float dy = cursoreY - playerY;
        float dx = cursoreX - playerX;

        float rotation = Mathf.Atan2(dy, dx) * Mathf.Rad2Deg;
        Cannon.transform.rotation = Quaternion.Euler(0, 0, (rotation + additionalTextureAngle) - gameObject.transform.rotation.z);
    }
    
    Vector2 calculateBulletDirection()
    {
        return new Vector2(findEnemy.transform.position.x - gameObject.transform.position.x , findEnemy.transform.position.y - gameObject.transform.position.y);
    } 
    
    void shoot(GameObject bullet)
    {
        if (AbleToShoot == true)
        { 
            GameObject thisbullet =  Instantiate(bullet, bulletSpawn.position, Quaternion.identity);
            thisbullet.GetComponent<BulletController>().GetDirection(calculateBulletDirection()); 
            AbleToShoot = false;
        }
    }

    void StartCDTimer()
    {
        exitTime = CD;
    }
}
