using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathLogic : MonoBehaviour
{
    public string enemyTag = "Enemy";
    public ParticleSystem blowUp;
    public float slowTimeDuration = 1;
    public float deathMenuTime = 0.5f;
    public float minScaledTime = 0.05f;
    public GameObject deathMenu;


    public void OnCollisionEnter2D(Collision2D col){
        if(col.collider.CompareTag(enemyTag)){
            KillBird();
        }

    }


    private void KillBird(){
        Debug.Log("Fågeln dog!");
        blowUp.Play();
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;
        StartCoroutine(SlowTime(slowTimeDuration));
    }

    IEnumerator SlowTime(float duration = 1){
        for(float t = 0; t < duration; t += Time.unscaledDeltaTime){
            Time.timeScale = Mathf.Lerp(1, minScaledTime, t/duration);

            if(t > deathMenuTime){
                deathMenu.SetActive(true);
            }

            yield return null;
        }
    }
}
