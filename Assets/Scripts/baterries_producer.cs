using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteriesProducer : MonoBehaviour
{
    public GameObject itemPrefab;  
    public GameObject particlesPrefab;  // Particle system for battery spawn effect
    public float radius;  // Radius to spawn the objects within
    public float lifespan = 5f;  // Time in seconds before battery is destroyed if not collected

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            SpawnObject();
        }
    }

    // Method to spawn a battery
    void SpawnObject()
    {
        Vector2 randomPos = Random.insideUnitCircle * radius;

        Instantiate(particlesPrefab, new Vector3(randomPos.x, randomPos.y, 0), Quaternion.identity);

        GameObject item = Instantiate(itemPrefab, new Vector3(randomPos.x, randomPos.y, 0), Quaternion.identity);

        StartCoroutine(DestroyObjectAfterTime(item, lifespan));
    }

    // Coroutine to destroy the object after a certain lifespan and then respawn it
    IEnumerator DestroyObjectAfterTime(GameObject obj, float time)
    {
        // Wait for the specified time
        yield return new WaitForSeconds(time);

        // Destroy the object
        Destroy(obj);

        // After it's destroyed, spawn a new object
        SpawnObject();
    }
}
