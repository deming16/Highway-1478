using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    bool gameHasEnded = false;
    public float restartDelay = 1f;

    public GameObject CompleteLevelUI;

    // variables for going into night
    public GameObject DarkPanel;
    public GameObject BrightPanel;
    public Camera cm;
    public GameObject PointLight;
    public GameObject DirectionalLight;

    public void endGame() {
        if (gameHasEnded == false) {
            gameHasEnded = true;
            Invoke("restart", restartDelay);
        }
    }

    void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void CompleteLevel()
    {
        CompleteLevelUI.SetActive(true);
    }

    public void TurnDark()
    {
        DarkPanel.SetActive(false);
        DarkPanel.SetActive(true);
        cm.clearFlags = CameraClearFlags.SolidColor;
        cm.backgroundColor = Color.black;
        RenderSettings.ambientIntensity = 0f;
        PointLight.SetActive(true);
        DirectionalLight.SetActive(false);

    }

    public void TurnBright()
    {
        BrightPanel.SetActive(false);
        BrightPanel.SetActive(true);
        cm.clearFlags = CameraClearFlags.Skybox;
        RenderSettings.ambientIntensity = 1f;
        PointLight.SetActive(false);
        DirectionalLight.SetActive(true);
    }

}
