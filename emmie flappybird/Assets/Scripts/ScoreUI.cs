using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreUI : MonoBehaviour
{
    private ScoreManager score;
    public TMP_Text text;

    // Start is called before the first frame update
    void Start()
    {
        score = FindObjectOfType<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = score.Score.ToString();
    }
}
