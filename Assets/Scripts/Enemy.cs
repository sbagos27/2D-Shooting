using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public delegate void EnemyDied(int points);
    public static event EnemyDied OnEnemyDied;
    private GameManager gm;
    public int enemyType;
    
    void Awake()
    {
        gm = FindObjectOfType<GameManager>();
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
      Debug.Log("Ouch!");
      gm.hitEnemy(enemyType);

      Destroy(collision.gameObject);
      
      OnEnemyDied?.Invoke(10);

      // todo kill enemy
    }
    
}
