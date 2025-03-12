using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MoveArmy : MonoBehaviour
{
    public float moveSpeed = 5f; 
    public float farthest = 4f; 
    private float startPositionX;

    public static int enemyCount = 24;
    
    public GameObject armyPrefab;
    
    public GameObject bulletPrefab;
    public Transform shottingOffset;

    private void newWave()
    {
        enemyCount = 24;
        SceneManager.LoadScene("CreditScene");
        
    }
    
    void Start()
    {
        startPositionX = transform.position.x; 
        StartCoroutine(Shoot());

    }

    IEnumerator Shoot()
    {
        while (true)
        {
            GameObject shot = Instantiate(bulletPrefab, shottingOffset.position, Quaternion.identity);

            Destroy(shot, 3f);
            yield return new WaitForSeconds(4f);

        }
        
    }

    void Update()
    {
        
        // transform.Translate(Vector3.right * (moveSpeed * Time.deltaTime));
        transform.position += Vector3.right * (moveSpeed * Time.deltaTime);

        if (transform.position.x > startPositionX + farthest || transform.position.x < startPositionX - farthest)
        {
            moveSpeed *= -1; 
            transform.position += Vector3.down*0.25f;
        }
        
        if (enemyCount == 0)
        {
            newWave();
        }
    }
}
