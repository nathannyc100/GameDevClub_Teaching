using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private CharacterController characterController;
    [SerializeField]
    private Enemy enemy;

    private int enemyCount;
    private float spawnDistance;

    private void Awake(){
        characterController = FindObjectOfType<CharacterController>();
    }

    public void SpawnEnemies(){

    }
}
