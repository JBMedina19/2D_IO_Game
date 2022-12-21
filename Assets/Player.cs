using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            GameManager.Instance.isGameFinished = true;
            PlayerRotation.Instance.StopRotation();
            Debug.Log("EnemyHit");
            transform.DOScale(0, 0.5f);
        }
    }
}
