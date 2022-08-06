using UnityEngine;

public class CanonRotateToCursore : MonoBehaviour
    {
        [SerializeField] private GameObject cursore;
        [SerializeField] private float additionalTextureAngle;
        void Update()
        {
            gameObject.transform.rotation = Quaternion.Euler(0, 0, CalculatRotationeAngle(gameObject) + additionalTextureAngle);
        }

        float CalculatRotationeAngle(GameObject player)
        {
            float cursoreX = cursore.transform.position.x;
            float cursoreY = cursore.transform.position.y;

            float playerX = player.transform.position.x;
            float playerY = player.transform.position.y;

            float dy = cursoreY - playerY;
            float dx = cursoreX - playerX;

            float rotation = Mathf.Atan2(dy, dx) * Mathf.Rad2Deg;
            return rotation;
        }
    }
