using System.Collections;
using UnityEngine;

public class ShowName : MonoBehaviour 
{
	public static string objName = "";

	public bool active = false;

	void OnMouseOver()
	{
		if(active)
		{
			objName = gameObject.name;		//If the cursor is over an object and active is true save the gameobject's name to objName.
		}
	}

	void OnMouseExit()
	{
		objName = "";						//If the cursor leaves the object change objName to "". This will make the text for this object turn off.
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