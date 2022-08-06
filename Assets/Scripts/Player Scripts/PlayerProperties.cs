using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerProperties : MonoBehaviour
{
    
    [SerializeField] public float playerSpeed;
    [SerializeField] public int bulletsAvailable; // field
    public int BulletsAvailable// property
    {
        get { return bulletsAvailable; }
        set
        {
            bulletsAvailable = value;
            _uiController.SetBulletsAvaible(bulletsAvailable);
        }
    }
    [SerializeField] private float maxHealth;
    [SerializeField] public CursoreController Cursore;

    private float availableHealth; // field
    public float AvailableHealth // property
    {
        get { return availableHealth;}
        set
        {
            availableHealth = value;
            _uiController.SetHealtbar(maxHealth, availableHealth);
            DieController();
        }
    }
    
    [SerializeField] private UIController _uiController;
    
    void Start()
    {
        _uiController.SetBulletsAvaible(bulletsAvailable);
        availableHealth = maxHealth;
    }

    void DieController()
    {
        if (availableHealth <= 0)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene( UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
        }
    }

}
