using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DialogFromFile : MonoBehaviour 
{
	public bool canTalkTo = false;
	public bool canLookAt = false;
	public TextAsset file;
	public Text textComponent;
	public GameObject textBox;
	public char newLineOn = '%';

    int startLine = 0;
    public int isAtLine = 0;
    int endLine = 0;

    public int defaultStartLine = 0;
    public int defaultEndLine = 2;

    public int eventStartLine = 0;
    public int eventEndLine = 2;

    public int ringStartLine = 0;
    public int ringEndLine = 2;

    public int drinkAStartLine = 0;
    public int drinkAEndLine = 2;

    public int bowlAStartLine = 0;
    public int bowlAEndLine = 2;

    public int hatOStartLine = 0;
    public int hatOEndLine = 2;

    public int bowlOStartLine = 0;
    public int bowlOEndLine = 2;

    public int drinkOStartLine = 0;
    public int drinkOEndLine = 2;

    public int ringOStartLine = 0;
    public int ringOEndLine = 2;


    public int startLookLine = 3;
	public int isAtLookLine = 3;
	public int endLookLine = 5;
	public string[] lines;

	private bool canTalk = false;
	private bool canLook = false;
	private bool isTalking = false;
	private bool isLooking = false;

    public GameObject theObject;

    public GameObject GController;
    GameControllerScript GCScript;

    bool isLineInitialized = false;

    void Start() 
	{


        GCScript = GController.GetComponent<GameControllerScript>();

		ErrorCheck ();
		HideTextBox();
		lines = file.text.Split(newLineOn);                             //Read the text file and save it as an array. Every "%" create a new line.
        textComponent.text = "";												//Don't show the text.
	}

	void Update() 
	{
		if(canLook && !isTalking)										//Look at the thing.
		{
            textComponent.text = lines[isAtLookLine]; 						//This will show the text from the array saved in this pos.
			isLooking = true;
			ShowTextBox();
			if(Input.GetKeyUp(KeyCode.Z))							//Press return.
			{
				isAtLookLine++;											//After pressing return add +1 to the line you are now.
			}

			if(isAtLookLine > endLookLine || Input.GetKeyUp(KeyCode.Escape))
			{
				EndDialog();											//End the dialog.
			}
		}
		
		if(canTalk && !isLooking)										//You talk to the thing.
		{
            if (GCScript.gameState == GameState.defaultState)
            {
                startLine = defaultStartLine;
                endLine = defaultEndLine;
            }
            else if (GCScript.gameState == GameState.level1EventStarted)
            {
                startLine = eventStartLine;
                endLine = eventEndLine;
            }
            else if (GCScript.gameState == GameState.ringFound)
            {
                startLine = ringStartLine;
                endLine = ringEndLine;
            }
            else if (GCScript.gameState == GameState.drinkAsked)
            {
                startLine = drinkAStartLine;
                endLine = drinkAEndLine;
            }
            else if (GCScript.gameState == GameState.bowlAsked)
            {
                startLine = bowlAStartLine;
                endLine = bowlAEndLine;
            }
            else if (GCScript.gameState == GameState.ringObtained)
            {
                startLine = ringOStartLine;
                endLine = ringOEndLine;
            }
            else if (GCScript.gameState == GameState.drinkObtained)
            {
                startLine = drinkOStartLine;
                endLine = drinkOEndLine;
            }
            else if (GCScript.gameState == GameState.bowlObtained)
            {
                startLine = bowlOStartLine;
                endLine = bowlOEndLine;
            }
            else if (GCScript.gameState == GameState.defaultState)
            {
                startLine = defaultStartLine;
                endLine = defaultEndLine;
            }

            if(isLineInitialized == false)
            {
                isAtLine = startLine;
                isLineInitialized = true;
            }

            textComponent.text = lines[isAtLine];							//The text will show the text of the array saved on this position.
            //Debug.Log("Line: " + lines[isAtLine] + ".");
			isTalking = true;
			ShowTextBox();

			if(Input.GetKeyUp(KeyCode.Z))							//Press return
			{
				isAtLine++;												//After pressing return add +1 to the line you are right now.
			}

			if(isAtLine > endLine || Input.GetKeyUp(KeyCode.Escape))
			{
				EndDialog();                                            //End the dialog.
            }
            EventCheck();
        }
	}

	void OnMouseOver()
	{
		if(Input.GetKeyUp(KeyCode.Mouse0) && !canLook && canTalkTo) 	//Left click "Action".
		{
			canTalk = true;
		}

		if(Input.GetKeyUp(KeyCode.Mouse1) && !canTalk && canLookAt) 	//Right click "Look".
		{
			canLook = true;
		}
	}

	void EndDialog()													//Reset to default.
	{
        textComponent.text = "";
		isTalking = false;
		isLooking = false;
		canTalk = false;
		canLook = false;
        isLineInitialized = false;
		isAtLine = 0;
		isAtLookLine = startLookLine;
		HideTextBox();

        if(gameObject.tag == "Ring")
        {
            GCScript.shadyLeaving = true;
        }
	}

	void ShowTextBox()
	{
		textBox.SetActive(true);
	}

	void HideTextBox()
	{
		textBox.SetActive(false);
	}

	void ErrorCheck()
	{
		if(file == null)												//No textfile set?
		{
			Debug.Log("ERROR for object -" + name + "- :You need to add a .txt file to your script!");
		}

		if(textComponent == null)											//No textmesh set?
		{
			Debug.Log("ERROR for object -" + name + "- :You need to add a textmesh to your script!");
		}

		if(textBox == null)												//No textBox set?
		{
			Debug.Log("ERROR for object -" + name + "- :You need to add a textBox to your script!");
		}

		if(!canLookAt && !canTalkTo)									//Can't talk or look?
		{
			Debug.Log("ERROR for object -" + name + "- :You need to set if you want to talk or/and look at this object!");
		}
	}

    void EventCheck()
    {
        if (GCScript.gameState == GameState.defaultState)
        {
            if (tag == "RingNPC")
            {
                GCScript.gameState = GameState.level1EventStarted;
            }
        }
        else if (GCScript.gameState == GameState.level1EventStarted)
        {
            if (tag == "Ring")
            {
                GCScript.gameState = GameState.ringFound;
            }
        }
        else if (GCScript.gameState == GameState.ringFound)
        {
            if(tag == "ShadyNPC")
            {
                GCScript.gameState = GameState.shadyTalkedTo;
            }
        }
        else if (GCScript.gameState == GameState.shadyTalkedTo)
        {
            if (tag == "ResNPC")
            {
                GCScript.gameState = GameState.drinkAsked;
            }
        }
        else if (GCScript.gameState == GameState.drinkAsked)
        {
            if(tag == "VendorNPC")
            {
                GCScript.gameState = GameState.bowlAsked;
            }
        }
        else if(GCScript.gameState == GameState.bowlAsked)
        {
            if(tag == "Hat")
            {
                GCScript.gameState = GameState.hatObtained;
            }
        }
        else if (GCScript.gameState == GameState.hatObtained)
        {
            if(tag == "VendorNPC")
            {
                GCScript.gameState = GameState.bowlObtained;
            }
        }
        else if(GCScript.gameState == GameState.bowlObtained)
        {
            if (tag == "ResNPC")
            {
                GCScript.gameState = GameState.drinkObtained;
            }
        }
        else if (GCScript.gameState == GameState.drinkObtained)
        {
            if (tag == "ShadyNPC")
            {
                GCScript.gameState = GameState.ringObtained;
            }
        }
        else if (GCScript.gameState == GameState.ringObtained)
        {
            if(tag == "RingNPC")
            {
                GCScript.gameState = GameState.level1Finished;
            }
        }
    }


}



/*
####################################################
############### -Point & Click Pack- ###############
####################################################
----------------------------------------------------

					    by
				 SchrippleAGaming


####################################################
###################### -Info- ######################
####################################################
----------------------------------------------------

If you need help like or want me to code something
for you just contact me! If you want you can show
me what games you made with the help of this pack.
Please let me know what you do like/don't like so
I know what to do in the future.
I'm happy to hear from you. :)


####################################################
#################### -Contact- #####################
####################################################
----------------------------------------------------
-Twitter-
@SchrippleAGamer

-E-Mail-
contact@schrippleagaming.net

-Website-
schrippleagaming.net

-Youtube-
youtube.com/c/SchrippleAGamingDe
----------------------------------------------------
*/