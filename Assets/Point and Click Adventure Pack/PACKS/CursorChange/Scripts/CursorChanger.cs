using System.Collections;
using UnityEngine;

public class CursorChanger : MonoBehaviour 
{
	public bool canUseAndLook = false;
	public bool canLook = false;
	public bool canTalkAndLook = false;
	public bool canGoAndLook = false;
	public bool sceneIsNext = false;
	public bool sceneIsBack = false;
	public Texture2D defaultCursor;
	public Texture2D useAndLook;
	public Texture2D talkAndLook;
	public Texture2D goAndLook;
	public Texture2D look;
	public Vector2 defaultSize = Vector2.zero;
	public Vector2 interactSize = Vector2.zero;

	private CursorMode cursorMode = CursorMode.ForceSoftware;


    public GameObject kamera;
    ChangeScenes CScript;


	void Start()
	{
		ErrorCheck();
		Cursor.SetCursor(defaultCursor, defaultSize/2, cursorMode);                 //Set default cursor texture.

        CScript = kamera.GetComponent<ChangeScenes>();
    }

	void OnMouseOver()
	{
		ShowThisCursor();
	}

	void OnMouseExit()
	{
		Cursor.SetCursor(defaultCursor, defaultSize/2, cursorMode);					//Reset cursor to default on object exit.
	}

	void ShowThisCursor()
	{
		if(gameObject.tag == gameObject.tag)
		{
			if(canGoAndLook)
			{
				if(sceneIsNext && Input.GetKeyUp(KeyCode.Mouse0))
				{
                    CScript.WhatScene(gameObject.tag);
				}

				if(sceneIsBack && Input.GetKeyUp(KeyCode.Mouse0))
				{
					ChangeScenes.backScene = true;									//Go -1 scene.
				}
			}

			if(canTalkAndLook)
			{
				if(talkAndLook != null)
				{
					Cursor.SetCursor(talkAndLook, interactSize/2, cursorMode);		//Set cursor texture for talkAndLook.

					if(Input.GetKeyUp(KeyCode.Mouse0)) 
					{
						//What happens if you press the left mouse button?
					}
					else if(Input.GetKeyUp(KeyCode.Mouse1)) 
					{
						Look();
					}
				}
			}

			if(canUseAndLook)
			{
				if(useAndLook != null)
				{
					Cursor.SetCursor(useAndLook, interactSize/2, cursorMode);		//Set cursor texture for useAndLook.

					if(Input.GetKeyUp(KeyCode.Mouse0)) 
					{
						//What happens if you press the left mouse button?
					}
					else if(Input.GetKeyUp(KeyCode.Mouse1)) 
					{
						Look();
					}
				}
			}

			if(canGoAndLook)
			{
				if(goAndLook != null)
				{
					Cursor.SetCursor(goAndLook, interactSize/2, cursorMode);		//Set cursor texture for goAndLook.

					if(Input.GetKeyUp(KeyCode.Mouse0)) 
					{
						//What happens if you press the left mouse button?
					}
					else if(Input.GetKeyUp(KeyCode.Mouse1)) 
					{
						Look();
					}
				}
			}

			if(canLook)
			{
				if(look != null)
				{
					Cursor.SetCursor(look, interactSize/2, cursorMode);				//Set cursor texture for look.

					if(Input.GetKey(KeyCode.Mouse1)) 
					{
						Look();
					}
				}
			}
		}
	}

	void Look()
	{
		//What happens if you press the right mouse button?
	}

	void ErrorCheck()
	{
		if(canLook && canGoAndLook || canLook && canUseAndLook || canLook && canTalkAndLook)	//Only one option set?
		{
			Debug.Log("ERROR for object -" + name + "- :Only one option can be picked! Please change your options for this object!");
		}

		if(!canGoAndLook && !canUseAndLook && !canTalkAndLook && !canLook)						//No option set?
		{
			Debug.Log("ERROR for object -" + name + "- :You haven't set the options for this object yet!");
		}

		if(canLook && look == null)																//No texture set?
		{
			Debug.Log("ERROR for object -" + name + "Please set a texture for: \"Look\"!");
		}

		if(canUseAndLook && useAndLook == null)													//No texture set?
		{
			Debug.Log("ERROR for object -" + name + "Please set a texture for: \"Use And Look\"!");
		}

		if(canTalkAndLook && talkAndLook == null)												//No texture set?
		{
			Debug.Log("ERROR for object -" + name + "Please set a texture for: \"Talk And Look\"!");
		}

		if(canGoAndLook && goAndLook == null)													//No texture set?
		{
			Debug.Log("ERROR for object -" + name + "Please set a texture for: \"Go And Look\"!");
		}

		if(defaultSize == Vector2.zero || interactSize == Vector2.zero)							//No texture size set?
		{
			Debug.Log("ERROR for object -" + name + "Please set a texture size for this object!");
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