using UnityEngine;

public class DayTrigger : MonoBehaviour {

    public GameManager gameManager;

    void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Player")
        {
            gameManager.TurnBright();
        }
    }
}
