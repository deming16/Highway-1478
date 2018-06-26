using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipTrigger : MonoBehaviour {

    public GameObject screen;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Player")
        {
            screen.GetComponent<CameraMovement>().startTime = Time.time;
            screen.GetComponent<CameraMovement>().flipEnter = true;          
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.tag == "Player")
        {
            screen.GetComponent<CameraMovement>().startTime = Time.time;
            screen.GetComponent<CameraMovement>().flipExit = true;       
        }
    }
}
