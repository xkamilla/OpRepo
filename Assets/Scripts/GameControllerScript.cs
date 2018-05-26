using System.Collections;
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

    public bool timerStart = false;
    public Text timeText;
    float time = 300.0f;
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

    bool timeIsShown = false;

    FirstCutSceneScript FCSScript;

    public GameObject finalGoodWitch;
    public GameObject finalBadWitch;
    public BoxCollider2D portalCollider;
    public BoxCollider2D portalRoomCollider;
    public bool artifactStolen = false;
    public TextAsset badEndFile;

    AudioController audioScript;

    public GameObject mapButton;
    public GameObject inventoryButton;

    bool gameOver = false;

    void Awake ()
    {
        gameState = GameState.startState;

        FCSScript = gameObject.GetComponent<FirstCutSceneScript>();
        audioScript = gameObject.GetComponent<AudioController>();

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
        startfadeOutImage.canvasRenderer.SetAlpha(1.0f);
        FadeIn(2.0f);
    }

    void Update()
    {
        CheckGameEvents();
        if (timerStart)
        {
            TimeUpdate();
        }
        if(!timeIsShown && gameState == GameState.shadyTalkedTo)
        {
            ShowTime();
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
                audioScript.PlayAudio("whistle");
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
            timerStart = false;
            timeText.gameObject.SetActive(false);
        }
        else if(gameState == GameState.level1FinishedBad)
        {
            artifCollider.enabled = false;
            artifRenderer.enabled = false;
            finalBadWitch.GetComponent<BoxCollider2D>().enabled = true;
            portalCollider.enabled = false;
            timerStart = false;
            timeText.gameObject.SetActive(false);
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
        Debug.Log("Faded");
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
        audioScript.StopAudio();
        gameOver = true;
        FadeToBlack(3);
        Debug.Log("FadeAsked");
        HideUI();
        ShowCreditsAndMenu();
    }
    void HideUI()
    {
        UICanvas.SetActive(false);
    }
    void ShowUIComp()
    {
        inventoryButton.SetActive(true);
        mapButton.SetActive(true);
    }
    void ShowTime()
    {
        timeText.gameObject.SetActive(true);
    }
    void ShowCreditsAndMenu()
    {
    }
}
