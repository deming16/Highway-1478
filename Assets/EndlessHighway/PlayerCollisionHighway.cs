using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionHighway : MonoBehaviour {

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Obstacle")
        {
            GetComponent<PlayerMovementHighway>().enabled = false;
            FindObjectOfType<GameManagerHighway>().endGame();
        }
    }
}
