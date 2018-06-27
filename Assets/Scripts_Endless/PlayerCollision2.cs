using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision2 : MonoBehaviour {


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Obstacle")
        {
            GetComponent<PlayerMovement2>().enabled = false;
            FindObjectOfType<GameManager2>().endGame();
        }
    }

}
