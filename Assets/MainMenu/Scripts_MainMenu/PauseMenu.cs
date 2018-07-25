using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour {

    public static bool GameIsPaused = false;
    public GameObject PauseMenuUI;
    public Text score;

	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown("p"))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
	}

    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void QuitGame()
    {
        string level = SceneManager.GetActiveScene().name.Substring(8);
        string privateCode;

        if (PlayerPrefs.GetInt(level + "Score", 0) < int.Parse(score.text))
        {
            PlayerPrefs.SetInt(level + "Score", int.Parse(score.text));
        }

        switch(level)
        {
            case "Highway":
                privateCode = "JkQun3thcUuRkaWAX_U4mARcKgolbVlkmoy6rsC7-T7Q";
                break;
            case "Dungeon":
                privateCode = "wLQXPkNC6UOl2qSYPneESwf0qATGENPUm3zswBrSayrA";
                break;
            default:
                privateCode = "vDXficLh5kWE8x_tdYDuZQiUQMFcu3Vk2pjAXJL3SJVg";
                break;
        }

        GetComponent<Highscores>().AddNewHighscore(PlayerStats.Username, int.Parse(score.text), privateCode);


        Destroy(GameObject.Find("AudioManager"));
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}
