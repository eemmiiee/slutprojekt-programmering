using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private int score = 0;
    public int Score{
        get{
            return score;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    public void Increment(int value = 1){
        score += value;
    }
}
