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
            GameObject.Find("AudioManager").GetComponent<AudioManagerGame>().Play("Crash");
            if (PlayerPrefs.GetInt("HighwayScore", 0) < int.Parse(score.text))
            {
                PlayerPrefs.SetInt("HighwayScore", int.Parse(score.text));
            }

            GetComponent<Highscores>().AddNewHighscore(PlayerStats.Username, int.Parse(score.text), "JkQun3thcUuRkaWAX_U4mARcKgolbVlkmoy6rsC7-T7Q");

            GetComponent<PlayerMovementHighway>().enabled = false;
            FindObjectOfType<GameManager>().endGame();
        }
    }
}
