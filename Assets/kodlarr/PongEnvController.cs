using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public enum Event
{
    LeftPaddleGoal = 0,
    RightPaddleGoal = 1
}

public class PongEnvController : MonoBehaviour
{
    [SerializeField] private PaddleAgent leftPaddleAgent;
    [SerializeField] private PaddleAgent rightPaddleAgent;
    [SerializeField] private Ball ball;
    [SerializeField] private SpriteRenderer middleLineRenderer;
    [SerializeField] private int maxEnvironmentSteps = 2000;
    private int resetTimer;

    public GameObject winText,loseText,Tekrar,Bilgi;
    public TextMeshProUGUI Sayac;
    private int Sol,Sag;
    private void Start() {
       Sol = 0;
       Sag = 0;
       StartCoroutine(Kazanir(1f));
    }
    public void ResolveEvent(Event triggerEvent)
    {
        switch (triggerEvent)
        {
            //Rewards for self-competitive play
            case Event.LeftPaddleGoal:
                leftPaddleAgent.AddReward(1f);
                rightPaddleAgent.AddReward(-1f);
                Sol++;
                if(Sol == 5)
                {
                    SceneManager.LoadScene("Home2");
                }
                StartCoroutine(SwapMiddleLineColor(Color.white, 0.5f));
                StartCoroutine(WinText(1f));
                leftPaddleAgent.EndEpisode();
                rightPaddleAgent.EndEpisode();
                break;
            case Event.RightPaddleGoal:
                leftPaddleAgent.AddReward(-1f);
                rightPaddleAgent.AddReward(1f);
                Sag++;
                if(Sag == 5)
                {
                    ResetScene();
                    Sag = 0;
                    Sol = 0;
                    StartCoroutine(Tekrardene(1f));
                }
                StartCoroutine(SwapMiddleLineColor(Color.white, 0.5f));
                StartCoroutine(LoseText(1f));
                leftPaddleAgent.EndEpisode();
                rightPaddleAgent.EndEpisode();
                break;
        }
    }
     private IEnumerator WinText(float time)
    {
        winText.SetActive(true);
        yield return new WaitForSeconds(time);
        winText.SetActive(false);
    }
    private IEnumerator LoseText(float time)
    {
        loseText.SetActive(true);
        yield return new WaitForSeconds(time);
        loseText.SetActive(false);
    }
    private IEnumerator SwapMiddleLineColor(Color color, float time)
    {
        middleLineRenderer.color = color;
        yield return new WaitForSeconds(time);
        middleLineRenderer.color = Color.white;
    }
    private IEnumerator Tekrardene(float time)
    {
        Tekrar.SetActive(true);
        yield return new WaitForSeconds(time);
        Tekrar.SetActive(false);
    }
    private IEnumerator Kazanir(float time)
    {
        Bilgi.SetActive(true);
        yield return new WaitForSeconds(time);
        Bilgi.SetActive(false);
    }

    private void ResetScene()
    {
        resetTimer = 0;
        ball.Launch();
    }

    private void FixedUpdate()
    {
        resetTimer += 1;
        if (resetTimer >= maxEnvironmentSteps && maxEnvironmentSteps > 0)
        {
            leftPaddleAgent.EpisodeInterrupted();
            rightPaddleAgent.EpisodeInterrupted();
            ResetScene();
        }
    }
    private void Update() {
       Sayac.text = "Skor   "+Sol+"-"+Sag;
    }
}
