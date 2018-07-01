using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCollisionDungeon : MonoBehaviour {

    public Text score;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Obstacle")
        {
            if (PlayerPrefs.GetInt("DungeonScore", 0) < int.Parse(score.text))
            {
                PlayerPrefs.SetInt("DungeonScore", int.Parse(score.text));
            }

            FindObjectOfType<Score>().enabled = false;
            GetComponent<PlayerMovementDungeon>().enabled = false;
            FindObjectOfType<GameManager>().endGame();
        }
    }

}
