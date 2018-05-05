using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    }

    void Update ()
    {
        CheckGameEvents();
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
                ringRenderer.enabled = false;
                ringCollider.enabled = false;
                ringPickedUp = true;
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
}
