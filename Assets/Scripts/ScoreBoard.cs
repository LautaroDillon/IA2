using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreBoard : MonoBehaviour
{
    public static ScoreBoard instance;

    public float score;


    private void Awake()
    {
        instance = this;
    }


    public void UpdateScore(float playerScore)
    {
        score = playerScore;
    }

}
