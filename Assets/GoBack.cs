using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GoBack : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene("INCLASSTHING");

    }
    
}
