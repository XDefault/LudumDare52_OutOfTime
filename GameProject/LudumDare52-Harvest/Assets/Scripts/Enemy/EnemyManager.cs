using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{   
    public static EnemyManager manager;
    public GameObject enemyPrefab;
    public List<GameObject> enemys;
    public Transform spawnPoint;

    float timer = 0;
    public float spawnRate = 5;
    private float speedMultiplier = 1;
    private int toRoundCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        manager = this;
        speedMultiplier = 1;
        toRoundCount = 10;
    }

    // Update is called once per frame
    void Update()
    {
        if(timer <= 0){
            timer = spawnRate;
            toRoundCount--;
            AddEnemy();
        }

        if(toRoundCount <= 0){
            toRoundCount = 5;
            speedMultiplier += 0.1f;
            if(spawnRate > 3){
                spawnRate -= 0.2f;
            }
        }

        timer -= Time.deltaTime;
    }

    void AddEnemy(){
        GameObject enemy = Instantiate(enemyPrefab,spawnPoint.position,Quaternion.identity);
        UnityEngine.AI.NavMeshAgent agent = enemy.GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.speed *= speedMultiplier;
        enemys.Add(enemy);
    }

    public void RemoveEnemy(GameObject obj){
        enemys.Remove(obj);
    }
}
