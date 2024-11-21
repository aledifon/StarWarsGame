using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab;
    [SerializeField]
    private Transform[] posRotEnemy;
    [SerializeField]
    private float timeBetweenEnemies;
    
    void Start()
    {
        InvokeRepeating("CreateEnemies",timeBetweenEnemies,timeBetweenEnemies);
    }

    private void CreateEnemies()
    {
        int n = Random.Range(0, posRotEnemy.Length); // Gen. Random nums for the array index

        Instantiate(enemyPrefab, posRotEnemy[n].position, posRotEnemy[n].rotation);

    }
}
