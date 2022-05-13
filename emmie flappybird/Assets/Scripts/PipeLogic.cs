using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeLogic : MonoBehaviour
{
    public GameObject pipePrefab;
    public float startX = 10;
    public float endX = -10;
    public float moveSpeed = 1;
    public float spawnTime = 3;


    List<GameObject> activePipes = new List<GameObject>();
    private float timer = 0;

    void Start(){
        SpawnPipe();
    }


    // Update is called once per frame
    void Update()
    {
        //spawn pipes at regular intervals
        if(timer == 0){
            SpawnPipe();
        }





        MovePipes();

        timer += Time.deltaTime;
        if(timer >= spawnTime) {
            RemovePipe();
            timer = 0;
        }
    }

    void SpawnPipe(){
        activePipes.Add(Instantiate(pipePrefab, new Vector3(startX,0,0), Quaternion.identity));
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
            pipe.transform.position += new Vector3(-moveSpeed, 0, 0) * Time.deltaTime;
        }
    }
}
