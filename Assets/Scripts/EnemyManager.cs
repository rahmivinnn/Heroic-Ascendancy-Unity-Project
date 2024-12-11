using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private GameObject[] enemyPrefab;
    [SerializeField] public Enemy curEnemy;
    [SerializeField] private Transform canvas;

    public static EnemyManager instance;

    private void Awake()
    {
        instance = this;
    }

    public void createNewEnemy()
    {
        GameObject enemyToSpawn = enemyPrefab[Random.Range(0, enemyPrefab.Length)];
        GameObject obj = Instantiate(enemyToSpawn, canvas);

        curEnemy = obj.GetComponent<Enemy>();
    }

    public void DefeatEnemy(GameObject enemy)
    {
        Destroy(enemy);
        createNewEnemy();
        GameManager.instance.BackgroundCheck();
    }
}
