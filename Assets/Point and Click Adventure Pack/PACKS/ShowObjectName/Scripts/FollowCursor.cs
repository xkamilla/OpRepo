using System.Collections;
using UnityEngine;

public class FollowCursor : MonoBehaviour 
{
	public float cursorPosZ = 10.0f;
	public TextMesh objNameShow;

	void Start()
	{
		ErrorChecker();
	}

	void Update() 
	{
		objNameShow.text = ShowName.objName; 								//Set text of objNameShow (TextMesh) to the name saved in objName (String).
		Vector3 cursorPos = Input.mousePosition;                            //READ the X,Y,Z pos and save it in cursorPos.
        cursorPos.z = cursorPosZ;											//Change the cursorPos Z pos to the value set in cursorPosZ.
		transform.position = Camera.main.ScreenToWorldPoint(cursorPos);		//Set the pos of the gameobject to the cursor pos.
	}

	void ErrorChecker()
	{
		if(objNameShow == null)												//Is there a player to move?
		{
			Debug.Log("ERROR for object -" + name + "Please add a textmesh to the FollowCursor script at Obj Name Show!");
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