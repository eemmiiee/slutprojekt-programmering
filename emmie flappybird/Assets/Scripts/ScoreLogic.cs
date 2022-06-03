using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreLogic : MonoBehaviour
{
    private ScoreManager score;

    void Start(){
        score = FindObjectOfType<ScoreManager>();
    }

    public void OnTriggerEnter2D(Collider2D col){
        score.Increment();
    }
}
