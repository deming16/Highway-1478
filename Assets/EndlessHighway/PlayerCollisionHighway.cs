using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCollisionHighway : MonoBehaviour {

    public Text score;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Obstacle")
        {
            if (PlayerPrefs.GetInt("HighwayScore", 0) < int.Parse(score.text))
            {
                PlayerPrefs.SetInt("HighwayScore", int.Parse(score.text));
            }

            GetComponent<PlayerMovementHighway>().enabled = false;
            FindObjectOfType<GameManager>().endGame();
        }
    }
}
