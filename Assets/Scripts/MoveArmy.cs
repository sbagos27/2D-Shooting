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
    AudioSource audioSrc;
    public AudioClip blastClip;
    public AudioClip deathClip;

    private void newWave()
    {
        enemyCount = 24;
        SceneManager.LoadScene("CreditScene");
        
    }

    public void playDeath()
    {
        audioSrc.clip = deathClip;
        audioSrc.Play();
    }
    
    void Start()
    {
        startPositionX = transform.position.x; 
        audioSrc = GetComponent<AudioSource>();
        StartCoroutine(Shoot());

    }

    IEnumerator Shoot()
    {
        while (true)
        {
            audioSrc.clip = blastClip;
            audioSrc.Play();
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
