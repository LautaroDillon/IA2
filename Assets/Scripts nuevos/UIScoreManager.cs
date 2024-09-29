using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class UIScoreManager : MonoBehaviour
{
    public Text scoreText;
    private int score;

    void Start()
    {
        score = 0;
        UpdateScoreUI();
    }

    public void AddScore(int points)
    {
        score += points;
        UpdateScoreUI();
    }

    void UpdateScoreUI()
    {
        scoreText.text = "Score: " + score;

        // LINQ: Ordenar la puntuación en función de los puntos obtenidos
        var scores = new[] { score }.OrderByDescending(s => s).ToList();
    }
}
