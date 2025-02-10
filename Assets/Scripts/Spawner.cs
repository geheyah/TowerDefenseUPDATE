using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Spawner : MonoBehaviour
{
    public GameObject enemy;
    public Transform spawn;

    public float duration = 3f;
    private float spawnTime;

    void Update()
    {
        spawnTime += Time.deltaTime;

        if (spawnTime >= duration)
        {
            spawnTime = 0;
            GameObject enemyObject = Instantiate(enemy, spawn.position, transform.rotation);
        }
    }
}




