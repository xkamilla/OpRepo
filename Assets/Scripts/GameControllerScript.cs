using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum GameState
{
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
    level1Finished
}

public class GameControllerScript : MonoBehaviour {

    public GameState gameState;

    public GameObject ring;
    public GameObject hat;
    Renderer ringRenderer;
    Renderer hatRenderer;
    BoxCollider2D ringCollider;
    BoxCollider2D hatCollider;

    public List<string> inventory = new List<string>();

    public bool event1HasHappened;
    bool ringAppeared;

    public bool ringFound;
    bool ringPickedUp, hatPickedUp;

    public GameObject shady;
    Animator shadyAnim;

    public bool shadyLeaving = false;
    public Text timeText;
    float time = 240.0f;
    int intTime;

	void Awake ()
    {
        gameState = GameState.defaultState;

        ringRenderer = ring.GetComponent<Renderer>();
        ringCollider = ring.GetComponent<BoxCollider2D>();
        hatRenderer = hat.GetComponent<Renderer>();
        hatCollider = hat.GetComponent<BoxCollider2D>();

        event1HasHappened = false;
        ringAppeared = false;

        ringFound = false;
        ringPickedUp = false;
        hatPickedUp = false;

        shadyAnim = shady.GetComponent<Animator>();
    }

    void Update ()
    {
        CheckGameEvents();
        TimeUpdate();
	}

    void CheckGameEvents()
    {
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
            else if(shadyLeaving)
            {
                shadyAnim.Play("ShadyLeave");
                shadyLeaving = false;
            }
        }
        else if(gameState == GameState.hatObtained)
        {
            if(!hatPickedUp)
            {
                hatRenderer.enabled = false;
                hatCollider.enabled = false;
                hatPickedUp = true;
            }
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
}
