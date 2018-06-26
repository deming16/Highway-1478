using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager2 : MonoBehaviour {

    bool gameHasEnded = false;
    public float restartDelay = 1f;

    private void Update()
    {
        if (Input.GetKey("p"))
        {
            SceneManager.LoadScene(0);
        }
    }
    public void endGame()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            Invoke("restart", restartDelay);
        }
    }

    void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
