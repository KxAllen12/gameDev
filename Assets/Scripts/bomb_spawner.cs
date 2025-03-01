using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombSpawner : MonoBehaviour
{
    public GameObject bombPrefab;  
    public float radius;  // Radius to spawn the bombs within
    public float lifespan = 5f;  // Time in seconds before bombs are destroyed if not collected

    // Start is called before the first frame update
    void Start()
    {
        // Spawn 10 bombs at the start
        for (int i = 0; i < 10; i++)
        {
            SpawnBomb();
        }
    }

    // Method to spawn a bomb
    void SpawnBomb()
    {
        Vector2 randomPos = Random.insideUnitCircle * radius;

        GameObject bomb = Instantiate(bombPrefab, new Vector3(randomPos.x, randomPos.y, 0), Quaternion.identity);

        StartCoroutine(DestroyBombAfterTime(bomb, lifespan));
    }

    // Coroutine to destroy the bomb after a certain lifespan and then respawn it
    IEnumerator DestroyBombAfterTime(GameObject bomb, float time)
    {
        // Wait for the specified time
        yield return new WaitForSeconds(time);

        // Destroy the bomb
        Destroy(bomb);

        // After it's destroyed, spawn a new bomb
        SpawnBomb();
    }
}
