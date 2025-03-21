﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
  public GameObject bulletPrefab;
  public Transform shottingOffset;

  Animator playerAnimator;
  public float moveSpeed = 5f;
  AudioSource audioSrc;
  public AudioClip blasterSound;
  public AudioClip deathSound;

  
  void Start()
  {
    audioSrc = GetComponent<AudioSource>();
    playerAnimator = GetComponent<Animator>();
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
        transform.Translate(Vector3.up * (moveSpeed * Time.deltaTime));

      }
      if (Input.GetKey(KeyCode.RightArrow))
      {
        transform.Translate(Vector3.down * (moveSpeed * Time.deltaTime));

      }
      
      if (Input.GetKeyDown(KeyCode.Space))
      {
        audioSrc.clip = blasterSound;
        audioSrc.Play();
        playerAnimator.SetTrigger("Shoot");
        GameObject shot = Instantiate(bulletPrefab, shottingOffset.position, Quaternion.identity);
        Debug.Log("Bang!");

        Destroy(shot, 3f);
      }
    }

  void OnCollisionEnter2D()
  {
    playerAnimator.SetTrigger("Death");
    StartCoroutine(StallForSeconds(.8f));

  }
  
  IEnumerator StallForSeconds(float seconds)
  {
    audioSrc.clip = deathSound;
    audioSrc.Play();
    yield return new WaitForSeconds(seconds);
    SceneManager.LoadScene("CreditScene");

  }
}
