﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum GameState
{
    startState,
    defaultState,
    level1EventStarted,
    ringFound,
    shadyTalkedTo,
    drinkAsked,
    bowlAsked,
    drinkObtained,
    bowlObtained,
    hatObtained,
    ringObtained,
    level1Finished,
    level1FinishedBad
}

public class GameControllerScript : MonoBehaviour {

    public GameState gameState;

    public GameObject ring;
    public GameObject hat;
    public GameObject artifact;
    Renderer ringRenderer;
    Renderer hatRenderer;
    Renderer artifRenderer;
    BoxCollider2D ringCollider;
    BoxCollider2D hatCollider;
    BoxCollider2D artifCollider;

    public List<string> inventory = new List<string>();

    public bool event1HasHappened;
    bool ringAppeared;

    public bool ringFound;
    bool ringPickedUp, hatPickedUp;

    public GameObject shady;
    Animator shadyAnim;
    public bool shadyLeaving = false;

    bool timerStart = false;
    public Text timeText;
    float time = 240.0f;
    int intTime;

    public Image startfadeOutImage;
    public Image fadeOutImage;

    public Image chosenImage;
    Animator fadeAnim;

    bool firstTime = true;

    public Camera starterCamera;
    public Camera gameCamera;

    public GameObject UICanvas;
    public GameObject CreditsCanvas;

    FirstCutSceneScript FCSScript;

    public GameObject finalGoodWitch;
    public GameObject finalBadWitch;
    public BoxCollider2D portalCollider;
    public BoxCollider2D portalRoomCollider;
    public bool artifactStolen = false;
    public TextAsset badEndFile;

    bool gameOver = false;

    void Awake ()
    {
        gameState = GameState.startState;

        FCSScript = gameObject.GetComponent<FirstCutSceneScript>();

        ringRenderer = ring.GetComponent<Renderer>();
        ringCollider = ring.GetComponent<BoxCollider2D>();
        hatRenderer = hat.GetComponent<Renderer>();
        hatCollider = hat.GetComponent<BoxCollider2D>();
        artifRenderer = artifact.GetComponent<Renderer>();
        artifCollider = artifact.GetComponent<BoxCollider2D>();

        event1HasHappened = false;
        ringAppeared = false;

        ringFound = false;
        ringPickedUp = false;
        hatPickedUp = false;

        shadyAnim = shady.GetComponent<Animator>();
    }
    void Start()
    {
        chosenImage = startfadeOutImage;
        startfadeOutImage.canvasRenderer.SetAlpha(0.0f);
    }

    void Update()
    {
        CheckGameEvents();
        if (timerStart)
        {
            TimeUpdate();
        }
    }

    void CheckGameEvents()
    {
        if(artifactStolen)
        {
            gameState = GameState.level1FinishedBad;
        }
        if(gameState == GameState.defaultState)
        {
            portalRoomCollider.enabled = true;
        }
        if (gameState == GameState.level1EventStarted)
        {
            if (!ringAppeared)
            {
                ringRenderer.enabled = true;
                ringCollider.enabled = true;
                ringAppeared = true;
            }
        }
        else if (gameState == GameState.ringFound)
        {
            if (!ringPickedUp)
            {
                shadyAnim.Play("ShadyWalk");
                StartCoroutine(WaitForShady());
                ringPickedUp = true;
            }
            else if (shadyLeaving)
            {
                shadyAnim.Play("ShadyLeave");
                shadyLeaving = false;
            }
        }
        else if (gameState == GameState.hatObtained)
        {
            if (!hatPickedUp)
            {
                hatRenderer.enabled = false;
                hatCollider.enabled = false;
                hatPickedUp = true;
            }
        }
        else if (gameState == GameState.level1Finished)
        {
            artifCollider.enabled = false;
            artifRenderer.enabled = false;
            finalGoodWitch.GetComponent<BoxCollider2D>().enabled = true;
            portalCollider.enabled = false;
        }
        else if(gameState == GameState.level1FinishedBad)
        {
            artifCollider.enabled = false;
            artifRenderer.enabled = false;
            finalBadWitch.GetComponent<BoxCollider2D>().enabled = true;
            portalCollider.enabled = false;
        }
    }
    IEnumerator WaitForShady()
    {
        yield return new WaitForSeconds(1);
        ringRenderer.enabled = false;
        ringCollider.enabled = false;
    }

    void TimeUpdate()
    {
        time -= Time.deltaTime;
        intTime = (int)time;
        timeText.text = intTime.ToString();
    }

    public void FadeToBlack(float transitionTime)
    {
        chosenImage.CrossFadeAlpha(1, transitionTime, false);
        if(firstTime)
        {
            StartCoroutine(FirstFadeWait());
            firstTime = false;
        }
    }
    public void FadeIn(float transitionTime)
    {
        chosenImage.CrossFadeAlpha(0, transitionTime, false);
    }

    IEnumerator FirstFadeWait()
    {
        yield return new WaitForSeconds(2);

        chosenImage = fadeOutImage;
        starterCamera.enabled = false;
        gameCamera.enabled = true;
        FadeIn(2);

        FCSScript.enabled = false;
    }
    public void GameOver()
    {
        gameOver = true;
        FadeToBlack(3);
        HideUI();
        ShowCreditsAndMenu();
    }
    void HideUI()
    {
        UICanvas.SetActive(false);
    }
    void ShowCreditsAndMenu()
    {
        CreditsCanvas.SetActive(true);
    }
}
