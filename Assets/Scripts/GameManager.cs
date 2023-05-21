using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private CharacterController characterController;
    [SerializeField]
    private Enemy enemy;
    [SerializeField]
    private GameObject[] spawnPositions;
    public List<GameObject> enemies;

    public int score;
    private float spawnDistance;

    private void Awake(){
        characterController = FindObjectOfType<CharacterController>();
    }

    private void Update(){
        if (enemies.Count == 0){
            SpawnEnemies();
        }
    }

    public void SpawnEnemies(){
        foreach (GameObject spawnPoints in spawnPositions){
            Enemy instantiatedEnemy  = Instantiate(enemy, spawnPoints.transform.position, Quaternion.identity);
            enemies.Add(instantiatedEnemy.gameObject);
        }
    }


}
