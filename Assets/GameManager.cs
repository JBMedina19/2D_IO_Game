using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using DG.Tweening;

using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public GameObject[] Startmenu;
    public GameObject[] GameOverMenu;

    public Button PlayAgain;
    public TextMeshProUGUI ScoreText;
    public int Score;
    public bool isGameFinished;
    public GameObject[] Spawn;
    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
        // Start is called before the first frame update
    void Start()
    {

    }

        // Update is called once per frame
    void Update()
    {
        ScoreText.SetText(Score.ToString());
        if (isGameFinished)
        {
            Spawn = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject enemy in Spawn)
            {
                enemy.transform.DOKill();
                enemy.transform.DOScale(0, 0.5f);
                StartCoroutine(MenuRoll());
               
            }
        }
    }

    IEnumerator MenuRoll()
    {
        yield return new WaitForSeconds(1);
        for (int i = 0; i < Startmenu.Length; i++)
        {
            Startmenu[i].transform.DOMoveY(10, 2).SetEase(Ease.Linear);
        }
        for (int i = 0; i < GameOverMenu.Length; i++)
        {
            GameOverMenu[i].transform.DOMoveY(0, 2).SetEase(Ease.Linear);
        }
    }

}
