using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionSkytrain : MonoBehaviour {


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Obstacle")
        {
            FindObjectOfType<Score>().enabled = false;
            GetComponent<PlayerMovementSkytrain>().enabled = false;
            FindObjectOfType<GameManager>().endGame();
        }
    }

}
