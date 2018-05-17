using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstCutSceneScript : MonoBehaviour {

    public GameObject kamera;

    public GameObject gameController;
    CutSceneDialog CSDialog;

    public GameObject player;
    Animator playerAnim;

    public GameObject startButton;
    public GameObject exitButton;

    float wantedLocation;
    bool moveToMainMenu = true;
    bool movingToMainMenu = false;

    Vector3 vektori;
    bool firstWait = true;
    bool cameraCanMove = false;
    public bool movePlayer = false;

	void Awake()
    {
        CSDialog = gameController.GetComponent<CutSceneDialog>();
		playerAnim = player.GetComponent<Animator>();
        vektori = new Vector3(0.08f, 0, 0);
	}
	
	void Update()
    {

        Debug.Log(wantedLocation == player.transform.position.x);
        if (!cameraCanMove)
        {
            StartCoroutine(MoveTimer());
        }
        else if(cameraCanMove)
        {
            wantedLocation = player.transform.position.x;
            MoveCamera();
        }

        if(movePlayer)
        {
            playerAnim.Play("PlayerContWalk");
        }
	}

    IEnumerator MoveTimer()
    {
        yield return new WaitForSeconds(2);
        cameraCanMove = true;
    }
    void MoveCamera()
    {
        if (kamera.transform.position.x < wantedLocation)
        {
            Debug.Log("Moving to wanted location");
            kamera.transform.position += vektori;
        }
        else if(moveToMainMenu && (wantedLocation == player.transform.position.x))
        {
            Debug.Log("Waiting for menu");
            StartCoroutine(MoveToMainMenu());
        }
        else if(movingToMainMenu)
        {
            Debug.Log("Moving to menu");
            kamera.transform.position += vektori;
        }
        else
        {
            cameraCanMove = false;
            //CSDialog.startDialog = true;
        }
    }
    IEnumerator MoveToMainMenu()
    {
        yield return new WaitForSeconds(2);
        moveToMainMenu = false;
        movingToMainMenu = true;
    }
}
