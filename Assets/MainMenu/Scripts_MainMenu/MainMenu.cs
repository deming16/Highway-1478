using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    public GameObject MainMenuUI;
    public GameObject EndlessSelectMenu;
    public GameObject[] EndlessSelectUI;
    public GameObject PlayerSelectMenu;
    public GameObject[] PlayerSelectUI;
    public GameObject ControlMenu;
    public GameObject CreditScene;
    public GameObject Leaderboard;
    public TMP_Text AvatarName;
    public TMP_Text Username;
    public GameObject Name;
    public Text NameText;
    public InputField Input;
    private int Index;

    public TMP_Text[] Scores;

    private void Start()
    {
        GameObject.Find("MainMenu").GetComponent<Animator>().SetBool("FirstLaunch", true);
        Username.text = "Welcome! " + PlayerStats.Username;
        Input.contentType = InputField.ContentType.Alphanumeric;
        Input.characterLimit = 15;
    }

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
        Scores[Index].text = "BEST : " + PlayerPrefs.GetInt(Scores[Index].name, 0).ToString();
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

    public void PlayerMenuBack()
    {
        PlayerSelectUI[Index].SetActive(false);
        PlayerSelectMenu.SetActive(false);
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
        if (Index - 1 < 0)
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

    public void NextPlayer()
    {
        PlayerSelectUI[Index].SetActive(false);
        Index = (Index + 1) % PlayerSelectUI.Length;
        PlayerSelectUI[Index].SetActive(true);
        AvatarName.text = PlayerSelectUI[Index].name;
    }

    public void PrevPlayer()
    {
        PlayerSelectUI[Index].SetActive(false);
        if (Index - 1 < 0)
        {
            Index = PlayerSelectUI.Length;
        }
        Index = (Index - 1) % PlayerSelectUI.Length;
        PlayerSelectUI[Index].SetActive(true);
        AvatarName.text = PlayerSelectUI[Index].name;
    }

    public void ControlMenuActivate()
    {
        MainMenuUI.SetActive(false);
        ControlMenu.SetActive(true);
    }

    public void BackControlMenu()
    {
        ControlMenu.SetActive(false);
        MainMenuUI.SetActive(true);
    }

    public void Credits()
    {
        MainMenuUI.SetActive(false);
        CreditScene.SetActive(true);
    }

    public void CreditsBack()
    {
        CreditScene.SetActive(false);
        MainMenuUI.SetActive(true);
    }

    public void LeaderboardMenu()
    {
        MainMenuUI.SetActive(false);
        Leaderboard.SetActive(true);
    }

    public void LeaderboardBack()
    {
        Leaderboard.SetActive(false);
        MainMenuUI.SetActive(true);
    }

    public void ChangeName()
    {
        Name.SetActive(true);
    }

    public void NameChanged()
    {
        
        PlayerStats.Username = NameText.text;
        Username.text = "Welcome! " + PlayerStats.Username;
        Name.SetActive(false);
    }

}
