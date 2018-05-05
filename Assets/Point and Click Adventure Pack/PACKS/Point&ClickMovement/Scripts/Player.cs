using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour 
{
	void Update()
	{
		CanPlayerMove.updatedPos = transform.position;		//Update players pos and send it to the CanPlayerMove script.
	}

	void OnTriggerStay2D(Collider2D col) 
	{
		if(col.tag == "CanGo")
		{
			CanPlayerMove.canMove = true;					//Player can move.
		}
	}

	void OnTriggerEnter2D(Collider2D col) 
	{
		if(col.tag == "Stop")
		{
			CanPlayerMove.canMove = false;					//Player can't move.
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