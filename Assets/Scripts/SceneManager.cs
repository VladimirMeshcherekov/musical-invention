using System.Collections;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class SceneManager : MonoBehaviour
{
    [SerializeField] private Transform player;
    [Space]
    [SerializeField] private float TimeToSpawnBulletsBox;
    [SerializeField] private GameObject BulletsBox;
    [Space] 
    [SerializeField] private float TimeToSpawnNPC;
    [SerializeField] private GameObject NPC;
    void Start()
    {
        StartCoroutine(SpawnBulletsBox());
        StartCoroutine(SpawnNPC());
    }

    IEnumerator SpawnBulletsBox()
    {
        yield return new WaitForSeconds(TimeToSpawnBulletsBox);
        Instantiate(BulletsBox,
            new Vector2(player.position.x + Random.Range(-10f, 10f), player.position.y + Random.Range(-10f, 10f)), 
            quaternion.identity);
        
        StartCoroutine(SpawnBulletsBox());
    }

    IEnumerator SpawnNPC()
    {
        yield return new WaitForSeconds(TimeToSpawnNPC);
        Instantiate(NPC,
            new Vector2(player.position.x + Random.Range(-40f, 40f), player.position.y + Random.Range(-40f, 40f)), 
            quaternion.identity);
        StartCoroutine(SpawnNPC());
    }

}
