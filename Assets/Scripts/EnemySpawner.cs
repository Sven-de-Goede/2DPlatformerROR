using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject enemy1Prefab;

    [SerializeField]
    private float enemy1Interval = 3.5f;

    private GameObject Player;
    // Start is called before the first frame update
    void Awake() 
    {
        // start spawner
        StartCoroutine(spawnEnemy(enemy1Interval, enemy1Prefab));
    }
    void Start()
    {
        // keep spawning around enemy
        Player = GameObject.FindGameObjectWithTag("Player");
        enemy1Interval -= 0.01f;
    }

    void Update() {
        transform.position = Player.transform.position;
    }

    // spawn enemy mechanic
    private IEnumerator spawnEnemy(float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(interval);
        GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(-10f, 10f), Random.Range(5f, 15f), 0), Quaternion.identity);
        StartCoroutine(spawnEnemy(interval, enemy));
    }
}