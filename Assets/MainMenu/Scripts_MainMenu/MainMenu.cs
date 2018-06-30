using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public GameObject MainMenuUI;
    public GameObject[] EndlessSelectUI;
    private int Index;

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void EndlessSelect()
    {
        Index = 0;
        MainMenuUI.SetActive(false);
        EndlessSelectUI[Index].SetActive(true);
    }

    public void EndlessPlay()
    {
        SceneManager.LoadScene("Endless_" + EndlessSelectUI[Index].name);
    }

    public void Back()
    {
        EndlessSelectUI[Index].SetActive(false);
        MainMenuUI.SetActive(true);
    }

    public void Next()
    {
        EndlessSelectUI[Index].SetActive(false);
        Index = (Index + 1) % EndlessSelectUI.Length;
        EndlessSelectUI[Index].SetActive(true);
    }

    public void Prev()
    {
        EndlessSelectUI[Index].SetActive(false);
        if(Index - 1 < 0)
        {
            Index = EndlessSelectUI.Length;
        }
        Index = (Index - 1) % EndlessSelectUI.Length;
        EndlessSelectUI[Index].SetActive(true);
    }
}
