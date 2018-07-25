using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;


public class DisplayHighscores : MonoBehaviour
{
    public TMP_Text[] highscoreFields;
    public Dropdown selectedLeaderboard;
    Highscores highscoresManager;
    private string publicCode = "5b37ce15191a8a0bccd5f43e";

    void Start()
    {
        for (int i = 0; i < highscoreFields.Length; i++)
        {
            highscoreFields[i].text = i + 1 + ". Fetching...";
        }

        highscoresManager = GetComponent<Highscores>();
        highscoresManager.DownloadHighscores(publicCode);
    }

    public void OnHighscoresDownloaded(Highscore[] highscoreList)
    {
        for (int i = 0; i < highscoreFields.Length; i++)
        {
            highscoreFields[i].text = "EMPTY!!!";
            if (i < highscoreList.Length)
            {
                highscoreFields[i].text = highscoreList[i].username + "  " + highscoreList[i].score;
            }
        }
    }

    public void boardActivate()
    {
        switch (selectedLeaderboard.value)
        {
            case 0:
                DisplayHighway();
                break;
            case 1:
                DisplayDungeon();
                break;
            default:
                DisplaySkytrain();
                break;
        }
    }

    public void DisplayHighway()
    {
        for (int i = 0; i < highscoreFields.Length; i++)
        {
            highscoreFields[i].text = i + 1 + ". Fetching...";
        }
        publicCode = "5b37ce15191a8a0bccd5f43e";
        highscoresManager.DownloadHighscores(publicCode);
    }

    public void DisplayDungeon()
    {
        for (int i = 0; i < highscoreFields.Length; i++)
        {
            highscoreFields[i].text = i + 1 + ". Fetching...";
        }
        publicCode = "5b56f34b191a8a0bcc7a4bd0";
        highscoresManager.DownloadHighscores(publicCode);
    }

    public void DisplaySkytrain()
    {
        for (int i = 0; i < highscoreFields.Length; i++)
        {
            highscoreFields[i].text = i + 1 + ". Fetching...";
        }
        publicCode = "5b56f43e191a8a0bcc7a50ec";
        highscoresManager.DownloadHighscores(publicCode);
    }
}



