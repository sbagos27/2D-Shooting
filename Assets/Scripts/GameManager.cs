using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highscoreText;
    public int score;
    private int highscore = 0;

    public void hitEnemy(int type)
    {
        MoveArmy.enemyCount--;
        if (type == 1)
        {
            score += 10;
        }
        else if (type == 2)
        {
            score += 20;
        }
        else if (type == 3)
        {
            score += 30;
        }
        else if (type == 4)
        {
            int[] possibleScores = { 100, 200, 300, 400, 500 };
            int randomScore = possibleScores[Random.Range(0, possibleScores.Length)];
            score += randomScore;
        }
        
        scoreText.text = $"Score\n{score:D4}";

        if (score > highscore)
        {
            highscore = score;
            PlayerPrefs.SetInt("Hi-Score", highscore);
            PlayerPrefs.Save(); 
            highscoreText.text = $"Hi-Score\n{highscore:D4}";
        }
    }
    
    void Start()
    {
        highscore = PlayerPrefs.GetInt("Hi-Score", 0);
        highscoreText.text = $"Hi-Score\n{highscore:D4}";
    }

    void Update()
    {
        
    }
}
