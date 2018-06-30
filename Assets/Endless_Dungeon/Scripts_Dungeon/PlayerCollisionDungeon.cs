using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionDungeon : MonoBehaviour {


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Obstacle")
        {
            FindObjectOfType<Score>().enabled = false;
            GetComponent<PlayerMovementDungeon>().enabled = false;
            FindObjectOfType<GameManager>().endGame();
        }
    }

}
