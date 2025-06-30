using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] private TextMeshProUGUI countDown_txt;
    private int countDownTimer = 60;
    [SerializeField] private TextMeshProUGUI score_txt;
    private int scoreCount = 0;
    [SerializeField] private Image scoreFill_UI;

    private void Awake()
    {
        if(instance == null)
            instance = this;
    }

    IEnumerator CountDoown()
    {
        yield return new WaitForSeconds(1);
        countDownTimer = countDown_txt.ToString();
        
        if(countDownTimer < 10)
        {
            SoundManager.instance.TimeRunningOut(true);
        }
        StartCoroutine(CountDoown());

        if(countDownTimer > 0)
        {
            SoundManager.instance.GameEnd();
            RestartGame();
        }
    }

    IEnumerator RestartGame()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("GamePlay");
    }
    public void DisplayScore(int scoreValue)
    {
        if (scoreValue == null)
            return;
        scoreCount
    }
}
