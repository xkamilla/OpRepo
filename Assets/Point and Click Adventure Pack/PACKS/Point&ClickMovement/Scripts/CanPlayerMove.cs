using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanPlayerMove : MonoBehaviour 
{
	public static bool canMove = true;
	public static Vector3 updatedPos;

	public GameObject playerToMove;
	public bool moveByDrag = false;
	public float speed = 0.025f;

	private Vector3 startPos;
	private Vector3 clickPos;
	private float cursorPosZ = 10.0f;

	void Start()
	{
		ErrorChecker();																							//Run error check.
		startPos = playerToMove.transform.position;																//Save players start pos.
		clickPos = startPos;																					//Set clicked pos to start pos.
	}

	void Update() 
	{
		if(!canMove)
		{
			clickPos = updatedPos;																				//Stop player.
		}
	}

	void LateUpdate() 
	{
		playerToMove.transform.position = Vector3.Lerp(playerToMove.transform.position, clickPos, speed);		//Move player to clicked pos.
	}

	void OnMouseOver()
	{
		if(tag == "CanGo")																						//If cursor is over object with this tag do this.
		{
			if(canMove)
			{
				if(Input.GetKeyUp(KeyCode.Mouse0) && !moveByDrag)
				{
					Vector3 cursorPos = Input.mousePosition;													//#########################
					cursorPos.z = cursorPosZ;																	//### Save clicked pos. ###
					clickPos = Camera.main.ScreenToWorldPoint(cursorPos);										//#########################
				}

				if(Input.GetKey(KeyCode.Mouse0) && moveByDrag)
				{
					Vector3 cursorPos = Input.mousePosition;
					cursorPos.z = cursorPosZ;
					clickPos = Camera.main.ScreenToWorldPoint(cursorPos);
				}
			}
		}
	}

	void ErrorChecker()
	{
		if(playerToMove == null)																				//Is there a player to move?
		{
			Debug.Log("ERROR for object -" + name + "You haven't set a player you want to move yet!");
		}

		if(speed < 0.009f || speed > 5.0f)																		//Speed to high/slow?
		{
			Debug.Log("ERROR for object -" + name + "Please don't set your player speed to hight or low! This can cause problems!");
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