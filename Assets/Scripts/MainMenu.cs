using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public GameObject MainMenuUI;
    public GameObject EndlessSelectUI;

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void EndlessSelect()
    {
        MainMenuUI.SetActive(false);
        EndlessSelectUI.SetActive(true);
    }

}
