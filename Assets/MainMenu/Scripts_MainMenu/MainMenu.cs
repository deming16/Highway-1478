using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

    public GameObject MainMenuUI;
    public GameObject EndlessSelectMenu;
    public GameObject[] EndlessSelectUI;
    public GameObject PlayerSelectMenu;
    public GameObject[] PlayerSelectUI;
    public TMP_Text AvatarName;
    private int Index;

    public TMP_Text[] Scores;

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void EndlessSelect()
    {
        PlayerSelectUI[Index].SetActive(false);
        PlayerStats.Avatar = Index;
        Index = 0;
        PlayerSelectMenu.SetActive(false);
        EndlessSelectMenu.SetActive(true);
        EndlessSelectUI[Index].SetActive(true);
        Scores[Index].text = "BEST : " + PlayerPrefs.GetInt(Scores[Index].name,0).ToString();
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
        Scores[Index].text = "BEST : " + PlayerPrefs.GetInt(Scores[Index].name, 0).ToString();
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
        Scores[Index].text = "BEST : " + PlayerPrefs.GetInt(Scores[Index].name, 0).ToString();
    }

    public void PlayerSelect()
    {
        Index = 0;
        MainMenuUI.SetActive(false);
        PlayerSelectMenu.SetActive(true);
        PlayerSelectUI[Index].SetActive(true);
        AvatarName.text = PlayerSelectUI[Index].name;
    }

    public void NextPlayer ()
    {
        PlayerSelectUI[Index].SetActive(false);
        Index = (Index + 1) % PlayerSelectUI.Length;
        PlayerSelectUI[Index].SetActive(true);
        AvatarName.text = PlayerSelectUI[Index].name;
    }

    public void PrevPlayer()
    {
        PlayerSelectUI[Index].SetActive(false);
        if(Index - 1 < 0)
        {
            Index = PlayerSelectUI.Length;
        }
        Index = (Index - 1) % PlayerSelectUI.Length;
        PlayerSelectUI[Index].SetActive(true);
        AvatarName.text = PlayerSelectUI[Index].name;
    }

    
}
