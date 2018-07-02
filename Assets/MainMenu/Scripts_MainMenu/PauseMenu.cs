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

        if (PlayerPrefs.GetInt(level + "Score", 0) < int.Parse(score.text))
        {
            PlayerPrefs.SetInt(level + "Score", int.Parse(score.text));
        }

        Destroy(GameObject.Find("AudioManager"));
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}
