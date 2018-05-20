using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CutSceneDialog : MonoBehaviour 
{
	public bool canTalkTo = false;
	public bool canLookAt = false;
	public TextAsset file;
	public Text textComponent;
	public GameObject textBox;
	public char newLineOn = '%';

    public int startLine = 0;
    public int isAtLine = 0;
    public int endLine = 0;

    public int startLookLine = 3;
	public int isAtLookLine = 3;
	public int endLookLine = 5;
	public string[] lines;

	private bool canTalk = false;
	private bool canLook = false;
	private bool isTalking = false;
	private bool isLooking = false;

    bool isLineInitialized = false;


    FirstCutSceneScript FCSScript;
    public bool startDialog = false;

    void Awake() 
	{
		ErrorCheck ();
		HideTextBox();
		lines = file.text.Split(newLineOn);                             //Read the text file and save it as an array. Every "%" create a new line.
        textComponent.text = "";                                                //Don't show the text.
        FCSScript = gameObject.GetComponent<FirstCutSceneScript>();
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
		
		if(startDialog)										//You talk to the thing.
		{
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

        startDialog = false;
        FCSScript.StartDialogOver();
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
        /*if (GCScript.gameState == GameState.defaultState)
        {
            if (tag == "RingNPC")
            {
                GCScript.gameState = GameState.level1EventStarted;
            }
        }*/
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