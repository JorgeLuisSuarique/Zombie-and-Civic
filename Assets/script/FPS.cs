using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPS : MonoBehaviour 
{
	float mouseX;                                                          /*This variable allows me to move the camera on the X-axis.*/
    float mouseY;                                                          /*This variable allows me to move the camera on the Y-axis.*/
    public bool InvertirMouse;                                             /*This measures the option of reversing the movement of the mausoleum.*/
	void Update()
	{
		mouseX += Input.GetAxis("Mouse X");                                /*to the mouseX is added the movements on the X-axis*/
        if (InvertirMouse)                                                  /*if you reverse the camera.*/
        {
			mouseY += Input.GetAxis("Mouse Y");                            /*to the mouseY is added the movements on the Y-axis*/
            mouseY = Mathf.Clamp(mouseY, - 45.0f, 45.0f);                  /*this makes the mouse Y have a maximum value and a minimum value in which to move.*/
        }
		else
		{
			mouseY -= Input.GetAxis("Mouse Y");                            /*se le resta al mouseY para cuando el jugado desea quitar la camara invertida*/
			mouseY = Mathf.Clamp(mouseY, - 45.0f, 45.0f);                  /*this makes the mouse Y have a maximum value and a minimum value in which to move.*/
        }
		transform.eulerAngles = new Vector3 (mouseY,mouseX,0);             /*Individual consultation*/
    }
}
