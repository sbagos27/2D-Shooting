using UnityEngine;

public class MoveArmy : MonoBehaviour
{
    public float moveSpeed = 5f; 
    public float farthest = 4f; 
    private float startPositionX;

    public static int enemyCount = 24;
    
    public GameObject armyPrefab;

    private void newWave()
    {
        enemyCount = 24;
        // Instantiate(armyPrefab);
        
    }
    
    void Start()
    {
        startPositionX = transform.position.x; 
    }

    void Update()
    {
        
        transform.Translate(Vector3.right * (moveSpeed * Time.deltaTime));

        if (transform.position.x > startPositionX + farthest || transform.position.x < startPositionX - farthest)
        {
            moveSpeed = -moveSpeed; 
            transform.Translate(Vector3.down * 0.5f);

        }
        

        if (enemyCount == 0)
        {
            newWave();
        }
    }
}
