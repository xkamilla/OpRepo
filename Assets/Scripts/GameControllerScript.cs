using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    defaultState,
    level1EventStarted,
    ringFound,
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

    public GameObject player;
    public GameObject ring;
    Renderer ringRenderer;
    BoxCollider2D ringCollider;


    public List<string> inventory = new List<string>();


    public bool event1HasHappened;
    bool event1IsDone;

    public bool ringFound;
    bool ringPickedUp;

	void Awake ()
    {
        gameState = GameState.defaultState;

        ringRenderer = ring.GetComponent<Renderer>();
        ringCollider = ring.GetComponent<BoxCollider2D>();

        event1HasHappened = false;
        event1IsDone = false;

        ringFound = false;
        ringPickedUp = false;
	}
	
	void Update ()
    {
        CheckGameEvents();
	}

    void CheckGameEvents()
    {
        if (event1HasHappened)
        {
            if(!event1IsDone)
            {
                ringRenderer.enabled = true;
                ringCollider.enabled = true;
                event1IsDone = true;
                Debug.Log("Event 1 (NPC) done");
            }
            else if(ringFound)
            {
                Debug.Log("Ring found");
                if(!ringPickedUp)
                {
                    ringRenderer.enabled = false;
                    ringCollider.enabled = false;
                    ringPickedUp = true;
                    Debug.Log("Event 2 (ring) done");
                }
            }
        }
    }
}
