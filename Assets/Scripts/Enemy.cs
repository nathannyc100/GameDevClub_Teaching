using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;

    private void Awake(){
        health = 100;
    }

    private void OnTriggerEnter(Collider collider) {
        if (collider.gameObject.tag == "Bullet"){
            health -= 10;

            Debug.Log("Health decreased, health: " + health);
        }
    }
}
