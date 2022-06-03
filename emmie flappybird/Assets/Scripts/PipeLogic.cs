using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeLogic : MonoBehaviour
{
    private ScoreManager score;
    public GameObject pipePrefab;
    public float startX = 10;
    public float endX = -10;
    public float maxHeight = 1;
    public float minHeight = -1;
    public float startMoveSpeed = 1;
    public float startSpawnTime = 3;
    public float scoreFactor = 3;


    List<GameObject> activePipes = new List<GameObject>();
    private float timer = 0;


    void Start(){
        score = FindObjectOfType<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //spawn pipes at regular intervals
        if(timer == 0){
            SpawnPipe();
        }

        



        MovePipes();
        float spawnTime = startSpawnTime * Mathf.Exp(score.Score * -1/scoreFactor);

        timer += Time.deltaTime;
        if(timer >= spawnTime) {
            RemovePipe();
            timer = 0;
        }
    }

    void SpawnPipe(){
        float randomHeight = Random.Range(minHeight, maxHeight);

        activePipes.Add(Instantiate(pipePrefab, new Vector3(startX,randomHeight,0), Quaternion.identity));
    }
    void RemovePipe(){
        for(int i = 0; i < activePipes.Count; i++){
            if(activePipes[i].transform.position.x < endX){
                Destroy(activePipes[i]);
                activePipes.RemoveAt(i);
            }
        }
    }
    void MovePipes(){
        foreach(GameObject pipe in activePipes){
            float moveSpeed = getMoveSpeed();
            pipe.transform.position += new Vector3(-moveSpeed, 0, 0) * Time.deltaTime;
        }
    }
    float getMoveSpeed(){
        return startMoveSpeed * (Mathf.Log(score.Score + 1)/scoreFactor + 1);
    }
}
