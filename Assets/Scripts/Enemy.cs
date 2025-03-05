using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public delegate void EnemyDied(int points);
    public static event EnemyDied OnEnemyDied;
    private GameManager gm;
    public int enemyType;

    public GameObject parent;
    
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
      Destroy(gameObject);
      MoveArmy.enemyCount--;
      MoveArmy moveArmy = parent.GetComponent<MoveArmy>();
      moveArmy.moveSpeed *= 1.1f;

    }
    
}
