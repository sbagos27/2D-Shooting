﻿using System;
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
    Animator enemyAnimator;

    void Start()
    {
        enemyAnimator = GetComponent<Animator>();
    }    
    void Awake()
    {
        gm = FindObjectOfType<GameManager>();
    }
    
    void OnCollisionEnter2D(Collision2D collision) {
        
        
      Debug.Log("Ouch!");
      
      gm.hitEnemy(enemyType);
      
      enemyAnimator.SetTrigger("Death");


      Destroy(collision.gameObject);
      
      OnEnemyDied?.Invoke(10);
      MoveArmy moveArmy = parent.GetComponent<MoveArmy>();
      if (moveArmy.moveSpeed >0)
      {
          moveArmy.moveSpeed += .25f;
      }
      else
      {
          moveArmy.moveSpeed -= .25f;
      }
      
      
      StartCoroutine(StallForSeconds(.4f, moveArmy));

    }
    IEnumerator StallForSeconds(float seconds, MoveArmy moveArmy)
    {
        moveArmy.playDeath(); 
        yield return new WaitForSeconds(seconds);
        Destroy(gameObject);
    }
    
}
