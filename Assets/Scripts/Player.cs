using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
  public GameObject bulletPrefab;

  public Transform shottingOffset;

  public float moveSpeed = 5f;
  
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

      if (Input.GetKey(KeyCode.LeftArrow))
      {
        transform.Translate(Vector3.left * (moveSpeed * Time.deltaTime));

      }
      if (Input.GetKey(KeyCode.RightArrow))
      {
        transform.Translate(Vector3.right * (moveSpeed * Time.deltaTime));

      }
      
      if (Input.GetKeyDown(KeyCode.Space))
      {
        GameObject shot = Instantiate(bulletPrefab, shottingOffset.position, Quaternion.identity);
        Debug.Log("Bang!");

        Destroy(shot, 3f);
      }
    }
}
