using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Spawner : MonoBehaviour
{
    public GameObject[] SpawnObjects;
    public float timer;
    public float SpawnTimer;
    public float speed;
    public float FinalPos;
    // Start is called before the first frame update
    void Start()
    {
        timer = SpawnTimer;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer<= 0)
        {
            SpawnEnemy();
        }
    }

    void SpawnEnemy()
    {
        GameObject enemyObj = Instantiate(SpawnObjects[Random.Range(0, SpawnObjects.Length)], transform.position, transform.rotation);
        enemyObj.transform.DOMoveX(FinalPos, speed).SetEase(Ease.Linear).OnComplete(()=> AddScore(enemyObj)); 
        timer = SpawnTimer;
        if (GameManager.Instance.isGameFinished)
        {
            enemyObj.transform.DOKill();
        }
    }

    void AddScore(GameObject enemyObj)
    {
        GameManager.Instance.Score++;
        Destroy(enemyObj.gameObject);
    }
}

