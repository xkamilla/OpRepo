using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FirstCutSceneScript : MonoBehaviour {

    public Camera starterCamera;

    CutSceneDialog CSDialog;

    public GameObject player;
    Animator playerAnim;

    public GameObject startButtons;
    Animator buttonsAnim;

    float wantedLocation;
    bool moveToMainMenu = true;
    bool movingToMainMenu = false;

    Vector3 speedVector;
    bool firstWait = true;
    bool cameraCanMove = false;
    public bool movePlayer = false;
    bool gameStarting = false;
    bool startFinished = false;

    float startTimer = 3.0f;

    GameControllerScript GCScript;
    AudioController audioScript;

    Button startAndExitButtons;

	void Awake()
    {
        startAndExitButtons = startButtons.GetComponentInChildren<Button>();
        startAndExitButtons.interactable = false;

        CSDialog = gameObject.GetComponent<CutSceneDialog>();
        GCScript = gameObject.GetComponent<GameControllerScript>();

        playerAnim = player.GetComponent<Animator>();
        buttonsAnim = startButtons.GetComponent<Animator>();
        speedVector = new Vector3(0.08f, 0, 0);

        audioScript = gameObject.GetComponent<AudioController>();
        audioScript.PlayAudio("ambiance");
    }
	
	void Update()
    {

        if (!cameraCanMove)
        {
            StartCoroutine(MoveTimer());
        }
        else if(cameraCanMove)
        {
            wantedLocation = player.transform.position.x;
            MoveCamera();
        }
	}
 
    IEnumerator MoveTimer()
    {
        yield return new WaitForSeconds(0.7f);
        cameraCanMove = true;
    }
    void MoveCamera()
    {
        if (firstWait && (starterCamera.transform.position.x <= wantedLocation))
        {
            starterCamera.transform.position += speedVector;
        }
        else if(moveToMainMenu && (wantedLocation == player.transform.position.x))
        {
            firstWait = false;
            StartCoroutine(MoveToMainMenu());
        }
        else if(movingToMainMenu)
        {
            starterCamera.transform.position += speedVector;
            if(starterCamera.transform.position.x >= -60.4)
            {
                movingToMainMenu = false;
                ShowMenu();
            }
        }
        else if (gameStarting)
        {
            if (starterCamera.transform.position.x > player.transform.position.x)
            {
                starterCamera.transform.position -= speedVector;
            }
            else
            {
                StartDialog();
                gameStarting = false;
            }
        }
        else if (startFinished)
        {
            starterCamera.transform.position += new Vector3(speedVector.x, 0.03f, 0);
        }
        else
        {
            cameraCanMove = false;
        }
    }

    IEnumerator MoveToMainMenu()
    {
        yield return new WaitForSeconds(2);
        moveToMainMenu = false;
        movingToMainMenu = true;
    }

    void ShowMenu()
    {
        startButtons.SetActive(true);
        startAndExitButtons.interactable = true;
        buttonsAnim.Play("ButtonAppearAnim");
    }
    void HideMenu()
    {
        startAndExitButtons.interactable = false;
        buttonsAnim.Play("ButtonDisappearAnim");
        startButtons.SetActive(false);
    }
    public void StartGame()
    {
        HideMenu();
        gameStarting = true;
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    void StartDialog()
    {
        CSDialog.startDialog = true;
    }
    public void StartDialogOver()
    {
        playerAnim.Play("PlayerContWalk");
        startFinished = true;
        GCScript.FadeToBlack(2);
        audioScript.StopAudio();
    }
}
