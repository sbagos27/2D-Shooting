using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
  public GameObject bulletPrefab;

  public Transform shottingOffset;

  void Start()
  {
    Enemy.OnEnemyDied += EnemyOnOnEnemyDied;
  }

  private void OnDestroy()
  {
    Enemy.OnEnemyDied -= EnemyOnOnEnemyDied;
  }

  private void EnemyOnOnEnemyDied(int points)
  {
    Debug.Log($"IK IT DIED, points: {points}");
  }

  void Update()
    {
      if (Input.GetKeyDown(KeyCode.Space))
      {
        GameObject shot = Instantiate(bulletPrefab, shottingOffset.position, Quaternion.identity);
        Debug.Log("Bang!");

        Destroy(shot, 3f);

      }
    }
}
