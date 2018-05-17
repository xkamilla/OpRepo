using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

    public GameObject player;
    Vector3 pPosition;
    float x;

	void Awake ()
    {
        pPosition = player.transform.position;
    }
	
	void Update ()
    {
        x = pPosition.x;
        Debug.Log("Player: " + pPosition.x + " Camera: " + transform.position.x);
        if(x <= pPosition.x)
        {
            do
            {
                x += 1.0f;
            } while (x <= pPosition.x);
        }
    }
}
