using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(PlayerProperties))]
public class Shoot : MonoBehaviour
{
    [Header("Shoot System")]
    private PlayerProperties _playerProperties;
    [SerializeField] private Transform _bulletSpawn;
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private KeyCode _shootButton;
    [SerializeField] private float _cooldownTime;
    [SerializeField] private int _bulletCostPerShoot;
    [SerializeField] private CursoreController _cursore;
    [SerializeField] private Image ShootButton;//скорее по фану
    bool _aviableToShoot = true;
    void Start()
    {
        _playerProperties = gameObject.GetComponent<PlayerProperties>();
        _cursore = _playerProperties.Cursore;
    }

    void Update()
    {
        if (Input.GetKeyDown(_shootButton))
        {
            TakeShoot();
        }
    }

    public void ShootFromUI()
    {
        TakeShoot();
    }

    void TakeShoot()
    {
        if (_playerProperties.BulletsAvailable <= 0)
        {
            return;
        }

        if (_aviableToShoot == false)
        {
            return;
        }

        GameObject thisBullet =  Instantiate(_bulletPrefab, _bulletSpawn.position, Quaternion.identity);
        thisBullet.GetComponent<BulletController>().GetDirection(calculateBulletDirection());
        StartCoroutine(Сooldown());
        _aviableToShoot = false;
        _playerProperties.BulletsAvailable -= _bulletCostPerShoot;
    }

    IEnumerator Сooldown(){
        ShootButton.color = Color.red;
        yield return new WaitForSecondsRealtime(_cooldownTime);
        _aviableToShoot = true;
        ShootButton.color = Color.white;
    }

    Vector2 calculateBulletDirection()
    {
        return new Vector2(_cursore.transform.position.x - gameObject.transform.position.x , _cursore.transform.position.y - gameObject.transform.position.y);
    }
}
