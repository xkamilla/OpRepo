using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeScenes : MonoBehaviour
{
	public bool nextScene;
	public static bool backScene;

	public Transform[] scenePos;
	public int sceneNumber = 0;

    public bool sceneChangePossible = true;

    string portalTag = "";

	void Start()
	{
		ErrorChecker();
	}


    public void WhatScene(string objectTag)
    {
        if (sceneChangePossible)
        {
            portalTag = objectTag;
            nextScene = true;
        }
    }


	void Update()
	{
		if(nextScene)			//Go to next scene (+1 scene).
		{
            //sceneNumber++;

            if (portalTag == "000")
			    transform.position = new Vector3(scenePos[0].position.x, scenePos[0].position.y, scenePos[0].position.z -10);
            else if (portalTag == "001")
                transform.position = new Vector3(scenePos[1].position.x, scenePos[1].position.y, scenePos[1].position.z - 10);
            else if (portalTag == "002")
                transform.position = new Vector3(scenePos[2].position.x, scenePos[2].position.y, scenePos[2].position.z - 10);
            else if (portalTag == "003")
                transform.position = new Vector3(scenePos[3].position.x, scenePos[3].position.y, scenePos[3].position.z - 10);
            else if (portalTag == "004")
                transform.position = new Vector3(scenePos[4].position.x, scenePos[4].position.y, scenePos[4].position.z - 10);
            else if (portalTag == "005")
                transform.position = new Vector3(scenePos[5].position.x, scenePos[5].position.y, scenePos[5].position.z - 10);
            else if (portalTag == "006")
                transform.position = new Vector3(scenePos[6].position.x, scenePos[6].position.y, scenePos[6].position.z - 10);
            else if (portalTag == "007")
                transform.position = new Vector3(scenePos[7].position.x, scenePos[7].position.y, scenePos[7].position.z - 10);
            else if (portalTag == "008")
                transform.position = new Vector3(scenePos[8].position.x, scenePos[8].position.y, scenePos[8].position.z - 10);
            else if (portalTag == "009")
                transform.position = new Vector3(scenePos[9].position.x, scenePos[9].position.y, scenePos[9].position.z - 10);

            nextScene = false;
		}

		/*if(backScene)			//Go to last scene (-1 scene).
		{
			sceneNumber--;
			transform.position = new Vector3(scenePos[sceneNumber].position.x, scenePos[sceneNumber].position.y, scenePos[sceneNumber].position.z);
			backScene = false;
		}*/
	}

	void ErrorChecker()
	{
		if(scenePos == null)	//Scene pos set?
		{
			Debug.Log("ERROR for object -" + name + "Please add your scenes to the script (emptys)!");
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