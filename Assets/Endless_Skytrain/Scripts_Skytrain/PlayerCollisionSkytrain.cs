using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCollisionSkytrain : MonoBehaviour {

    public Text score;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Obstacle")
        {
            GameObject.Find("AudioManager").GetComponent<AudioManagerGame>().Play("Crash");
            FindObjectOfType<Score>().enabled = false;

            if (PlayerPrefs.GetInt("SkytrainScore", 0) < int.Parse(score.text))
            {
                PlayerPrefs.SetInt("SkytrainScore", int.Parse(score.text));
            }

            GetComponent<PlayerMovementSkytrain>().enabled = false;
            FindObjectOfType<GameManager>().endGame();
        }
    }

}
