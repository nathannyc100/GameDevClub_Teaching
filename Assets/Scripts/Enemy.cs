using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;

    private void Awake(){
        health = 100;
    }

    private void Update(){ 
        if (health <= 0){ 
            Destroy(gameObject);
        }
    }
}
